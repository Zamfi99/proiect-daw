using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DAW_Yacht.Models
{
    public class BookingModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("fk_booking_user_id")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [ForeignKey("fk_booking_yacht_id")]
        public int YachtId { get; set; }
        // [Required]
        public virtual YachtModel Yacht { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
        [Required]
        public float Price { get; set; }

        
    }
}