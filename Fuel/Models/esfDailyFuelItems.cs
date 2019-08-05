using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fuel.Models
{
    public class esfDailyFuelItems
    {
        [Timestamp]
        public byte[] HIID { get; set; }
        [Key]
        [Required]
        public int dfiID { get; set; }
        [Required]
        public int dcID { get; set; }
        [ForeignKey("dcID")]
        public dcDocuments dcDocuments { get; set; }
        [Required]
        public int eoID { get; set; }
        public mnEnergyObjects mnEnergyObjects { get; set; }
        [Required]
        public int fuID { get; set; }
        public esfFuelTypes esfFuelTypes { get; set; }
        [Required]
        public int Income { get; set; }
        [Required]
        public int Outcome { get; set; }
        [Required]
        public int Remains { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        public DateTime CreateAt { get; set; }
        public int CreateBy { get; set; }
        public DateTime EditAt { get; set; }
        public int EditBy { get; set; }
    }
}
