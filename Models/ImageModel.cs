using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAW_Yacht.Models
{
    public class ImageModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Filename { get; set; }
        // one to many
        public virtual ICollection<GalleryModel> Galleries { get; set; } 
    }
}