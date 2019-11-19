using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fuel.ViewModel
{
    public class DailyFuelItemsViewModel
    {
        [Timestamp]
        public byte[] HIID { get; set; }
        [Key]
        [Required]
        public int dfiID { get; set; }
        [Required]
        public int dcID { get; set; }
        [Required]
        public int eoID { get; set; }
        public int eoCode { get; set; }
        public string EnObjName { get; set; }
        [Required]
        public int fuID { get; set; }
        public int FuelCode { get; set; }
        [StringLength(100)]
        public string FuelName { get; set; }
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
