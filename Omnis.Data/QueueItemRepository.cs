// -----------------------------------------------------------------------
// <copyright file="QueueItemRepository.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Omnis.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Omnis.Business.Models;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class QueueItemRepository : IQueueItemRepository
    {
        public List<QueueItem> Items;
        
        public List<QueueItem> Select()
        {
            // generate mock data.
            var result = new List<QueueItem>
                {
                    new QueueItem
                        {
                            Id = 1,
                            ItemStatus = QueueItemStatus.InProgress,
                            Name = "QueueItem1",
                            Resource = "c:\\temp\\sample.csv",
                            Created = DateTime.Now.ToUniversalTime(),
                            Modified =  DateTime.Now.ToUniversalTime(),
                            ModifiedBy = "Benjamin"
                        },
                        new QueueItem
                        {
                            Id = 2,
                            ItemStatus = QueueItemStatus.Completed,
                            Name = "QueueItem2",
                            Resource = "c:\\temp\\sample.csv",
                            Created = DateTime.Now.ToUniversalTime(),
                            Modified =  DateTime.Now.ToUniversalTime(),
                            ModifiedBy = "Benjamin"
                        },
                        new QueueItem
                        {
                            Id = 3,
                            ItemStatus = QueueItemStatus.Failed,
                            Name = "QueueItem3",
                            Resource = "c:\\temp\\sample.csv",
                            Created = DateTime.Now.ToUniversalTime(),
                            Modified =  DateTime.Now.ToUniversalTime(),
                            ModifiedBy = "Benjamin"
                        },
                        new QueueItem
                        {
                            Id = 4,
                            ItemStatus = QueueItemStatus.Pending,
                            Name = "QueueItem4",
                            Resource = "c:\\temp\\sample.csv",
                            Created = DateTime.Now.ToUniversalTime(),
                            Modified =  DateTime.Now.ToUniversalTime(),
                            ModifiedBy = "Benjamin"
                        },
                        new QueueItem
                        {
                            Id = 5,
                            ItemStatus = QueueItemStatus.InProgress,
                            Name = "QueueItem5",
                            Resource = "c:\\temp\\sample.csv",
                            Created = DateTime.Now.ToUniversalTime(),
                            Modified =  DateTime.Now.ToUniversalTime(),
                            ModifiedBy = "Benjamin"
                        }
                };
            Items = result;
            return result;
        }

        public int AddOrUpdate(QueueItem item)
        {
            int id;
            if(this.Items.FirstOrDefault(p => p.Id == item.Id) == null)
            {
                // add
                Items.Add(item);
                id = item.Id;
            }
            else
            {
                // update
                var updatedItem = Items.Single(p => p.Id == item.Id);
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

        public bool Remove(int id)
        {
            var item = new QueueItem();
            item.Id = id;
            return Items.Remove(item);
        }

        public QueueItem SelectById(int id)
        {
            return Items.First(p => p.Id == id);
        }
    }
}
