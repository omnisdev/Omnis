// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQueueItemRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The i queue item repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Omnis.Data
{
    using System.Collections.Generic;

    using Omnis.Business.Models;

    /// <summary>
    /// The i queue item repository.
    /// </summary>
    public interface IQueueItemRepository
    {
        #region Public Methods and Operators

        /// <summary>
        /// The add or update.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The add or update.
        /// </returns>
        int AddOrUpdate(QueueItem item);

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The remove.
        /// </returns>
        bool Remove(int id);

        /// <summary>
        /// The select.
        /// </summary>
        /// <returns>
        /// </returns>
        List<QueueItem> Select();

        /// <summary>
        /// The select by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// </returns>
        QueueItem SelectById(int id);

        #endregion
    }
}