// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapLegendRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The i map legend repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Omnis.Data
{
    using System.Collections.Generic;

    using Omnis.Business.Models;

    /// <summary>
    /// The i map legend repository.
    /// </summary>
    public interface IMapLegendRepository
    {
        #region Public Methods and Operators

        /// <summary>
        /// The add or update.
        /// </summary>
        /// <param name="item">
        /// </param>
        void AddOrUpdate(MapLegend item);

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void Remove(MapLegend item);

        /// <summary>
        /// The clear.
        /// </summary>
        void RemoveAll();

        /// <summary>
        /// The select all.
        /// </summary>
        /// <returns>
        /// </returns>
        List<MapLegend> Select();

        #endregion
    }
}