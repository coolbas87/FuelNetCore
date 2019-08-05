using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fuel.Models
{
    public class mnEnergyObjects
    {
        [Timestamp]
        public byte[] HIID { get; set; }
        [Key]
        [Required]
        public int eoID { get; set; }
        public int eoCode { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public int CreateBy { get; set; }
        public DateTime EditAt { get; set; }
        public int EditBy { get; set; }
    }
}
