// -----------------------------------------------------------------------
// <copyright file="ColorMap.cs" company="">
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
    public class ColorMap
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Range(0,255)]
        public byte R { get; set; }

        [Range(0, 255)]
        public byte G { get; set; }

        [Range(0, 255)]
        public byte B { get; set; }
    }
}
