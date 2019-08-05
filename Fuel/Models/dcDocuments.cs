using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fuel.Models
{
    public class dcDocuments
    {
        [Timestamp]
        public byte[] HIID { get; set; }
        [Key]
        [Required]
        public int dcID { get; set; }
        [Required]
        [StringLength(35)]
        public string dcNo { get; set; }
        [Required]
        public DateTime dcDate { get; set; }
        [Required]
        [StringLength(20)]
        public string dcType { get; set; }
        [Required]
        public int emID { get; set; }
        [StringLength(500)]
        public string Comment { get; set; }
        public DateTime CreateAt { get; set; }
        public int CreateBy { get; set; }
        public DateTime EditAt { get; set; }
        public int EditBy { get; set; }
    }
}
