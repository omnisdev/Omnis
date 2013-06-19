// -----------------------------------------------------------------------
// <copyright file="Log.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Omnis.Business.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using FileHelpers;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [DelimitedRecord(",")]
    [IgnoreFirst(1)]
    [IgnoreEmptyLines]
    public class Log
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets TimeStamp.
        /// </summary>
        public string TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets Latitude.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets Longtitude.
        /// </summary>
        public double Longtitude { get; set; }

        /// <summary>
        /// Gets or sets Altitude.
        /// </summary>        
        public double Altitude { get; set; }

        /// <summary>
        /// Gets or sets Distance.
        /// </summary>
        public string Distance { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets Technology.
        /// </summary>
        public string Technology { get; set; }

        /// <summary>
        /// Gets or sets Signal.
        /// </summary>
        public int Signal { get; set; }

        /// <summary>
        /// Gets or sets Carrier.
        /// </summary>
        public string Carrier { get; set; }

        /// <summary>
        /// Gets or sets ModelName.
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// Gets or sets MMC.
        /// </summary>
        public int MCC { get; set; }

        /// <summary>
        /// Gets or sets MNC.
        /// </summary>
        public int MNC { get; set; }

        /// <summary>
        /// Gets or sets IMSI.
        /// </summary>
        public string IMSI { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets SysName.
        /// </summary>
        public string SysName { get; set; }

        /// <summary>
        /// Gets or sets SysVer.
        /// </summary>
        public string SysVer { get; set; }

        /// <summary>
        /// Gets or sets PhoneNumber.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets SignalBar.
        /// </summary>
        public int SignalBar { get; set; }

        /// <summary>
        /// Gets or sets BatteryLevel.
        /// </summary>
        public int BatteryLevel { get; set; }

        /// <summary>
        /// Gets or sets CellId.
        /// </summary>
        public int CellId { get; set; }

        /// <summary>
        /// Gets or sets LAC.
        /// </summary>
        public int LAC { get; set; }

        /// <summary>
        /// Gets or sets Signal2.
        /// </summary>
        public int Signal2 { get; set; }

        /// <summary>
        /// Gets or sets Technology2.
        /// </summary>
        public string Technology2 { get; set; }

        /// <summary>
        /// Gets or sets Reachability.
        /// </summary>
        public string Reachability { get; set; }

        #endregion
    }
}
