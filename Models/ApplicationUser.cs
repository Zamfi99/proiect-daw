using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DAW_Yacht.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<BookingModel> BookingModels { get; set; }
    }
}