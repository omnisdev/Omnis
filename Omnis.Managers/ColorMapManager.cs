// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorMapManager.cs" company="">
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
    public class ColorMapManager
    {
        #region Constants and Fields

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ColorMapRepository repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorMapManager"/> class.
        /// </summary>
        public ColorMapManager()
        {
            this.repository = new ColorMapRepository();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add or update.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void AddOrUpdate(ColorMap item)
        {
            this.repository.AddOrUpdate(item);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// </returns>
        public List<ColorMap> Get()
        {
            return this.repository.Select();
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Remove(ColorMap item)
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