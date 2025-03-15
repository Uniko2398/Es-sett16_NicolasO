using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoliziaMunicipale.Models;
using PoliziaMunicipaleApp.Data;
using PoliziaMunicipaleApp.Models;

namespace PoliziaMunicipaleApp.Services
{
    public class VerbaliService : IVerbaliService
    {
        private readonly PoliziaContext _context;

        public VerbaliService(PoliziaContext context)
        {
            _context = context;
        }

        public async Task<List<Verbale>> GetVerbaliAsync() => await _context.Verbali.Include(v => v.Anagrafica).Include(v => v.Violazione).ToListAsync();

        public async Task AddVerbaleAsync(Verbale verbale)
        {
            _context.Verbali.Add(verbale);
            await _context.SaveChangesAsync();
        }
    }
}