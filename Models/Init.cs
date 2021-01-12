using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAW_Yacht.Models
{
    public class Init
    {
        private readonly ModelsContext _context;

        public Init(ModelsContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            PozieModel pozie1 = new PozieModel{
                Autor = "Ion Popescu",
                Titlu = "Ursul Pacalit de Vulpe",
                Strofe = 4
            };
            
            PozieModel pozie2 = new PozieModel{
                Autor = "Mihai Eminovici",
                Titlu = "Luceafarul",
                Strofe = 98
            };
            
            PozieModel pozie3 = new PozieModel{
                Autor = "Mihai Eminovici",
                Titlu = "Luceafarul",
                Strofe = 98
            };
            
            PozieModel pozie4 = new PozieModel{
                Autor = "Autor 4",
                Titlu = "Pozie 4",
                Strofe = 4
            };
            
            PozieModel pozie5 = new PozieModel{
                Autor = "Autor 5",
                Titlu = "Poezie 5",
                Strofe = 5
            };
            
            PozieModel pozie6 = new PozieModel{
                Autor = "Autor 6",
                Titlu = "Pozie 6",
                Strofe = 6
            };
            
            
            await _context.Poezii.AddAsync(pozie1);
            await _context.Poezii.AddAsync(pozie2);
            await _context.Poezii.AddAsync(pozie3);
            await _context.Poezii.AddAsync(pozie4);
            await _context.Poezii.AddAsync(pozie5);
            await _context.Poezii.AddAsync(pozie6);

            VolumModel volum1 = new VolumModel
            {
                Denumire = "Volum 1",
                PozieModels = new List<PozieModel>()
            };
            
            volum1.PozieModels.Add(pozie1);
            volum1.PozieModels.Add(pozie2);
            
            VolumModel volum2 = new VolumModel
            {
                Denumire = "Volum 2",
                PozieModels = new List<PozieModel>()
            };
            
            volum2.PozieModels.Add(pozie3);
            volum2.PozieModels.Add(pozie4);
            
            VolumModel volum3 = new VolumModel
            {
                Denumire = "Volum 3",
                PozieModels = new List<PozieModel>()
            };
            
            volum3.PozieModels.Add(pozie5);
            volum3.PozieModels.Add(pozie6);
            
            await _context.Volume.AddAsync(volum1);
            await _context.Volume.AddAsync(volum2);
            await _context.Volume.AddAsync(volum3);
        }
    }
}