// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OmnisParser.cs" company="">
//   
// </copyright>
// <summary>
//   The omnis parser.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Omnis.Service
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.ServiceProcess;
    using System.Timers;

    using FileHelpers;

    using Omnis.Business.Models;
    using Omnis.Managers;

    /// <summary>
    /// The omnis parser.
    /// </summary>
    internal partial class OmnisParser : ServiceBase
    {
        #region Constants and Fields

        /// <summary>
        /// The log manager.
        /// </summary>
        private readonly LogManager logManager;

        /// <summary>
        /// The timer.
        /// </summary>
        private readonly Timer timer;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OmnisParser"/> class.
        /// </summary>
        public OmnisParser()
        {
            this.InitializeComponent();

            this.ServiceName = "Omnis Parser Service";
            this.EventLog.Log = "Application";

            this.CanHandlePowerEvent = true;
            this.CanHandleSessionChangeEvent = true;
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.CanStop = true;

            this.logManager = new LogManager();

            this.timer = new Timer(2000D);
            this.timer.AutoReset = true;
            this.timer.Elapsed += this.timer_Elapsed;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The on continue.
        /// </summary>
        protected override void OnContinue()
        {
            base.OnContinue();
            this.timer.Start();
        }

        /// <summary>
        /// The on pause.
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
            this.timer.Stop();
        }

        /// <summary>
        /// The on shutdown.
        /// </summary>
        protected override void OnShutdown()
        {
            base.OnShutdown();
            this.timer.Stop();
        }

        /// <summary>
        /// The on start.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        protected override void OnStart(string[] args)
        {
            this.timer.Start();
        }

        /// <summary>
        /// The on stop.
        /// </summary>
        protected override void OnStop()
        {
            this.timer.Stop();
        }

        /// <summary>
        /// The parse csv.
        /// </summary>
        /// <param name="file">
        /// The file.
        /// </param>
        private void ParseCsv(string file)
        {
            this.timer.Stop();
            try
            {
                if (File.Exists(file))
                {
                    var engine = new FileHelperEngine(typeof(Log));
                    engine.ErrorManager.ErrorMode = ErrorMode.IgnoreAndContinue;
                    var logs = engine.ReadFile(file) as Log[];

                    foreach (Log log in logs)
                    {
                        this.logManager.AddOrUpdate(log);
                    }

                    // logErrors = new List<LogException>();
                    // if (engine.ErrorManager.HasErrors)
                    // {
                    // foreach (var err in engine.ErrorManager.Errors)
                    // {
                    // var linenumber = err.LineNumber;
                    // var record = err.RecordString;
                    // var exception = err.ExceptionInfo.Message;
                    // var item = new LogException
                    // {
                    // LineNumber = linenumber,
                    // ExceptionMessage = exception,
                    // RecordString = record
                    // };
                    // logErrors.Add(item);
                    // }
                    // }
                    // BindToGrid(logs);
                    File.Delete(file);
                }
            }
            catch (Exception ex)
            {
                this.EventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                this.timer.Start();
            }
        }

        /// <summary>
        /// The timer_ elapsed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // check filesystem for dropped file, C:\Omnis\Queue
            foreach (string file in Directory.GetFiles("c:\\Omnis\\Queue", "*.csv"))
            {
                this.ParseCsv(file);
            }
        }

        #endregion
    }
}