namespace Omnis.Data
{
    using System.Collections.Generic;

    using Omnis.Business.Models;

    public interface IQueueItemRepository
    {
        List<QueueItem> Select();

        int AddOrUpdate(QueueItem item);

        bool Remove(int id);

        QueueItem SelectById(int id);        
    }
}