using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoliziaMunicipale.Models;
using PoliziaMunicipale.Services;
using PoliziaMunicipaleApp.Data;
using PoliziaMunicipaleApp.Models;

namespace PoliziaMunicipaleApp.Services
{
    public class AnagraficheService : IAnagraficheService
    {
        private readonly PoliziaContext _context;

        public AnagraficheService(PoliziaContext context)
        {
            _context = context;
        }

        public async Task<List<Anagrafica>> GetAnagraficheAsync() => await _context.Anagrafiche.ToListAsync();

        public async Task<Anagrafica> GetAnagraficaByIdAsync(int id) => await _context.Anagrafiche.FindAsync(id);

        public async Task AddAnagraficaAsync(Anagrafica anagrafica)
        {
            _context.Anagrafiche.Add(anagrafica);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAnagraficaAsync(Anagrafica anagrafica)
        {
            _context.Anagrafiche.Update(anagrafica);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAnagraficaAsync(int id)
        {
            var anagrafica = await _context.Anagrafiche.FindAsync(id);
            if (anagrafica != null)
            {
                _context.Anagrafiche.Remove(anagrafica);
                await _context.SaveChangesAsync();
            }
        }
    }
}