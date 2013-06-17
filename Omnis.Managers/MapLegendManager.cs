// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapLegendManager.cs" company="">
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
    public class MapLegendManager
    {
        #region Constants and Fields

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly IMapLegendRepository repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MapLegendManager"/> class.
        /// </summary>
        public MapLegendManager()
        {
            this.repository = new MapLegendRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapLegendManager"/> class.
        /// </summary>
        /// <param name="rep">
        /// The rep.
        /// </param>
        public MapLegendManager(IMapLegendRepository rep)
        {
            this.repository = rep;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add or update.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void AddOrUpdate(MapLegend item)
        {
            this.repository.AddOrUpdate(item);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// </returns>
        public List<MapLegend> Get()
        {
            return this.repository.Select();
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Remove(MapLegend item)
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