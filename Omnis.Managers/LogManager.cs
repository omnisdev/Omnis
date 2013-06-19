// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogManager.cs" company="">
//   
// </copyright>
// <summary>
//   TODO: Update summary.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Omnis.Managers
{
    using System.Collections.Generic;

    using Omnis.Business.Models;
    using Omnis.Data;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LogManager
    {
        #region Constants and Fields

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly LogRepository repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogManager"/> class.
        /// </summary>
        public LogManager()
        {
            this.repository = new LogRepository();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add or update.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void AddOrUpdate(Log item)
        {
            this.repository.AddOrUpdate(item);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// </returns>
        public List<Log> Get()
        {
            return this.repository.Select();
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Remove(Log item)
        {
            this.repository.Remove(item);
        }

        /// <summary>
        /// The remove all.
        /// </summary>
        public void RemoveAll()
        {
            this.repository.RemoveAll();
        }

        #endregion
    }
}