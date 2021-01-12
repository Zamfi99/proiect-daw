using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;

namespace DAW_Yacht.Models
{
    public class ModelsContext : DbContext
    {
        public DbSet<PozieModel> Poezii { get; set; }
        public DbSet<VolumModel> Volume { get; set; }
        public ModelsContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VolumModel>()
                .HasMany(v => v.PozieModels)
                .WithOne(p => p.Volum);

            VolumModel volum1 = new VolumModel
            {
                Id = 1,
                Denumire = "Volum 1",
            };

            VolumModel volum2 = new VolumModel
            {
                Id = 2,
                Denumire = "Volum 2",
            };

            VolumModel volum3 = new VolumModel
            {
                Id = 3,
                Denumire = "Volum 3",
            };

            modelBuilder.Entity<VolumModel>().HasData(
                volum1, volum2, volum3);
            
            PozieModel pozie1 = new PozieModel{
                Id = 1,
                Autor = "Ion Popescu",
                Titlu = "Ursul Pacalit de Vulpe",
                Strofe = 4,
                VolumId = 1
            };
            
            PozieModel pozie2 = new PozieModel{
                Id = 2,
                Autor = "Mihai Eminovici",
                Titlu = "Luceafarul",
                Strofe = 98,
                VolumId = 1
            };
            
            PozieModel pozie3 = new PozieModel{
                Id = 3,
                Autor = "Mihai Eminovici",
                Titlu = "Luceafarul",
                Strofe = 98,
                VolumId = 2
            };
            
            PozieModel pozie4 = new PozieModel{
                Id = 4,
                Autor = "Autor 4",
                Titlu = "Pozie 4",
                Strofe = 4,
                VolumId = 2
            };
            
            PozieModel pozie5 = new PozieModel{
                Id = 5,
                Autor = "Autor 5",
                Titlu = "Poezie 5",
                Strofe = 5,
                VolumId = 3
            };
            
            PozieModel pozie6 = new PozieModel{
                Id = 6,
                Autor = "Autor 6",
                Titlu = "Pozie 6",
                Strofe = 6,
                VolumId = 3
            };


            modelBuilder.Entity<PozieModel>().HasData(
                pozie1, pozie2, pozie3, pozie4, pozie5, pozie6);

        }
    }
}