using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fuel.Models
{
    public class mnEnergyObjectFiles
    {
        [Timestamp]
        public byte[] HIID { get; set; }
        [Key]
        [Required]
        public int eoflID { get; set; }
        [Required]
        public int eoID { get; set; }
        public mnEnergyObjects mnEnergyObjects { get; set; }
        [Required]
        [StringLength(1024)]
        public string Path { get; set; }
        [Required]
        [StringLength(10)]
        public string Filename { get; set; }
        [Required]
        [StringLength(10)]
        public string DateFormat { get; set; }
        [Required]
        [StringLength(3)]
        public string FileExt { get; set; }
        public bool IsDefault { get; set; }
    }
}
