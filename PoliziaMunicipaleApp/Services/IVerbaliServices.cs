using System.Collections.Generic;
using System.Threading.Tasks;
using PoliziaMunicipale.Models;
using PoliziaMunicipaleApp.Models;

namespace PoliziaMunicipaleApp.Services
{
    public interface IVerbaliService
    {
        Task<List<Verbale>> GetVerbaliAsync();
        Task AddVerbaleAsync(Verbale verbale);
    }
}