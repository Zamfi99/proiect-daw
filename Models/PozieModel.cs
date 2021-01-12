using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DAW_Yacht.Models
{
    public class PozieModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Autor { get; set; }
        [Required]
        [MaxLength(500)]
        public string Titlu { get; set; }
        [Required]
        public int Strofe { get; set; }
        
        [ForeignKey("fk_volum_model")]
        public int VolumId { get; set; }
        
        public virtual VolumModel Volum { get; set; }
    }
}