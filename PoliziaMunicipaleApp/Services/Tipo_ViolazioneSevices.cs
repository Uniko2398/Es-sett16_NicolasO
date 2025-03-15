using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoliziaMunicipale.Models;
using PoliziaMunicipaleApp.Data;
using PoliziaMunicipaleApp.Models;

namespace PoliziaMunicipaleApp.Services
{
    public class Tipo_ViolazioniService : IViolazioniService
    {
        private readonly PoliziaContext _context;

        public Tipo_ViolazioniService(PoliziaContext context)
        {
            _context = context;
        }

        public async Task<List<Tipo_Violazione>> GetViolazioniAsync() => await _context.Violazioni.ToListAsync();

        Task<List<Tipo_Violazione>> IViolazioniService.GetViolazioniAsync()
        {
            throw new NotImplementedException();
        }
    }
}