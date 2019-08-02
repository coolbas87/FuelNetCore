using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fuel.Models
{
    public class mnEnergyObjectFuel
    {
        [Timestamp]
        public byte[] HIID { get; set; }
        [Key]
        [Required]
        public int eofID { get; set; }
        [Required]
        public int eoID { get; set; }
        public mnEnergyObjects mnEnergyObjects { get; set; }
        [Required]
        public int fuID { get; set; }
        public esfFuelTypes esfFuelTypes { get; set; }
    }
}
