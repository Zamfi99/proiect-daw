using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAW_Yacht.Models
{
    public class GalleryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdYacht { get; set; }
        // one to many
        public virtual ICollection<ImageModel> IdImages { get; set; }
    }
}