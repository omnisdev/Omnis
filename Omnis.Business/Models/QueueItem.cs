// -----------------------------------------------------------------------
// <copyright file="QueueItem.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Omnis.Business.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class QueueItem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Resource { get; set; }

        [Required]
        public QueueItemStatus ItemStatus { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified { get; set; }

        [Required]
        public string ModifiedBy { get; set; }
    }

    public enum QueueItemStatus
    {
        Pending,
        InProgress,
        Completed,
        Failed
    }
}
