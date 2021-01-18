using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAW_Yacht.Models
{
    public class YachtModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "int(10)")]
        public int Length { get; set; }
        [Required]
        [Column(TypeName = "int(10)")]
        public int Rooms { get; set; }
        [Required]
        [Column(TypeName = "int(10)")]
        public int Capacity { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public float BasePrice { get; set; }
        
        [ForeignKey("fk_booking_gallery_id")]
        public int GalleryId { get; set; }
        // one to one
        [Column(TypeName = "int(10)")]
        public virtual GalleryModel Gallery { get; set; }
        
        
        
        public virtual ICollection<BookingModel> BookingModels { get; set; }
        
        // [ForeignKey("fk_yacht_booking_id")]
        // public BookingModel BookingId { get; set; }
    }
}