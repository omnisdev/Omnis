// -----------------------------------------------------------------------
// <copyright file="SignalLegent.cs" company="">
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
    public class SignalLegend
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int ColorId { get; set; }

        public string Display { get; set; }
    }
}
