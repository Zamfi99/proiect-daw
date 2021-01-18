using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAW_Yacht.Models
{
    public class ModelsContext : DbContext
    {
        public DbSet<YachtModel> Yachts { get; set; }
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<GalleryModel> Gallery { get; set; }
        public DbSet<BookingModel> Booking { get; set; }
        public DbSet<PriceModel> Price { get; set; }
        public DbSet<ApplicationUser> User { get; set; }
        public ModelsContext(DbContextOptions options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.ToTable("AspNetUsers");
            });
        }
    }
}