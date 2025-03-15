using System.Collections.Generic;
using System.Threading.Tasks;
using PoliziaMunicipale.Models;
using PoliziaMunicipaleApp.Models;

namespace PoliziaMunicipaleApp.Services
{
    public interface IViolazioniService
    {
        Task<List<Tipo_Violazione>> GetViolazioniAsync();
    }
}