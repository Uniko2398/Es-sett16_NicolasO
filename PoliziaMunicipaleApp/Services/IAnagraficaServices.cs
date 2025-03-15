using System.Collections.Generic;
using System.Threading.Tasks;
using PoliziaMunicipale.Models;
using PoliziaMunicipaleApp.Models;

namespace PoliziaMunicipale.Services
{
    public interface IAnagraficheService
    {
        Task<List<Anagrafica>> GetAnagraficheAsync();
        Task<Anagrafica> GetAnagraficaByIdAsync(int id);
        Task AddAnagraficaAsync(Anagrafica anagrafica);
        Task UpdateAnagraficaAsync(Anagrafica anagrafica);
        Task DeleteAnagraficaAsync(int id);
    }
}