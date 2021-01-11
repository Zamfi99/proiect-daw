using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DAW_Yacht.Models
{
    public class PriceModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
        [Required]
        [DefaultValue(0.0)]
        public float Grow { get; set; }
    }
}