using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace DAW_Yacht.Models
{
    public class ImageModel
    {
        [Key]
        public int Id { get; set; }
        // [Required]
        // [MaxLength(500)]
        // public string Filename { get; set; }
        
        [NotMapped]
        public IFormFile Filename { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string RealFilename { get; set; }
        // one to many
        public ICollection<GalleryModel> Galleries { get; set; } 
    }
}