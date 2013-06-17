// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueueItemRepository.cs" company="">
//   
// </copyright>
// <summary>
//   TODO: Update summary.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Omnis.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Omnis.Business.Models;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class QueueItemRepository : IQueueItemRepository
    {
        #region Constants and Fields

        /// <summary>
        /// The items.
        /// </summary>
        public List<QueueItem> Items;

        #endregion

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
        public int AddOrUpdate(QueueItem item)
        {
            int id;
            if (this.Items.FirstOrDefault(p => p.Id == item.Id) == null)
            {
                // add
                this.Items.Add(item);
                id = item.Id;
            }
            else
            {
                // update
                QueueItem updatedItem = this.Items.Single(p => p.Id == item.Id);
                updatedItem.Modified = DateTime.Now.ToUniversalTime();
                updatedItem.ModifiedBy = item.ModifiedBy;
                updatedItem.Created = item.Created;
                updatedItem.ItemStatus = item.ItemStatus;
                updatedItem.Name = item.Name;
                updatedItem.Resource = item.Resource;
                updatedItem.Id = item.Id;
                id = item.Id;
            }

            return id;
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The remove.
        /// </returns>
        public bool Remove(int id)
        {
            var item = new QueueItem();
            item.Id = id;
            return this.Items.Remove(item);
        }

        /// <summary>
        /// The select.
        /// </summary>
        /// <returns>
        /// </returns>
        public List<QueueItem> Select()
        {
            // generate mock data.
            var result = new List<QueueItem> {
                    new QueueItem
                        {
                            Id = 1, 
                            ItemStatus = QueueItemStatus.InProgress, 
                            Name = "QueueItem1", 
                            Resource = "c:\\temp\\sample.csv", 
                            Created = DateTime.Now.ToUniversalTime(), 
                            Modified = DateTime.Now.ToUniversalTime(), 
                            ModifiedBy = "Benjamin"
                        }, 
                    new QueueItem
                        {
                            Id = 2, 
                            ItemStatus = QueueItemStatus.Completed, 
                            Name = "QueueItem2", 
                            Resource = "c:\\temp\\sample.csv", 
                            Created = DateTime.Now.ToUniversalTime(), 
                            Modified = DateTime.Now.ToUniversalTime(), 
                            ModifiedBy = "Benjamin"
                        }, 
                    new QueueItem
                        {
                            Id = 3, 
                            ItemStatus = QueueItemStatus.Failed, 
                            Name = "QueueItem3", 
                            Resource = "c:\\temp\\sample.csv", 
                            Created = DateTime.Now.ToUniversalTime(), 
                            Modified = DateTime.Now.ToUniversalTime(), 
                            ModifiedBy = "Benjamin"
                        }, 
                    new QueueItem
                        {
                            Id = 4, 
                            ItemStatus = QueueItemStatus.Pending, 
                            Name = "QueueItem4", 
                            Resource = "c:\\temp\\sample.csv", 
                            Created = DateTime.Now.ToUniversalTime(), 
                            Modified = DateTime.Now.ToUniversalTime(), 
                            ModifiedBy = "Benjamin"
                        }, 
                    new QueueItem
                        {
                            Id = 5, 
                            ItemStatus = QueueItemStatus.InProgress, 
                            Name = "QueueItem5", 
                            Resource = "c:\\temp\\sample.csv", 
                            Created = DateTime.Now.ToUniversalTime(), 
                            Modified = DateTime.Now.ToUniversalTime(), 
                            ModifiedBy = "Benjamin"
                        }
                };
            this.Items = result;
            return result;
        }

        /// <summary>
        /// The select by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// </returns>
        public QueueItem SelectById(int id)
        {
            return this.Items.First(p => p.Id == id);
        }

        #endregion
    }
}