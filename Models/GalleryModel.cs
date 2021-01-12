using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAW_Yacht.Models
{
    public class GalleryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        // one to many
        public ICollection<ImageModel> ImageModels { get; set; }
    }
}