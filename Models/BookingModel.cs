using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DAW_Yacht.Models
{
    public class BookingModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public IdentityUser User { get; set; }
        [Required]
        public YachtModel Yacht { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
        [Required]
        public float Price { get; set; }
    }
}