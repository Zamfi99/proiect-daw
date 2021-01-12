using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DAW_Yacht.Models
{
    public class VolumModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Denumire { get; set; }
        
        public virtual ICollection<PozieModel> PozieModels { get; set; }
    }
}