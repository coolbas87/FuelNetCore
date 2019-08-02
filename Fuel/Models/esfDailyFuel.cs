using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fuel.Models
{
    public class esfDailyFuel : dcDocuments
    {
        public List<esfDailyFuelItems> Items { get; set; }
    }
}
