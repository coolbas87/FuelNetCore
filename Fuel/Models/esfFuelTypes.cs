﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fuel.Models
{
    public class esfFuelTypes
    {
        [Timestamp]
        public byte[] HIID { get; set; }
        [Key]
        [Required]
        public int fuID { get; set; }
        [Required]
        public int Code { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public bool IsHasIncome { get; set; }
        [Required]
        public bool IsHasOutcome { get; set; }
        [Required]
        public bool IsHasRemains { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public DateTime CreateAt { get; set; }
        public int CreateBy { get; set; }
        public DateTime EditAt { get; set; }
        public int EditBy { get; set; }
    }
}
