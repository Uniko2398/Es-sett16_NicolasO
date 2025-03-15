using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipaleApp.Services;
using System.Threading.Tasks;

namespace PoliziaMunicipaleApp.Controllers
{
    public class ViolazioniController : Controller
    {
        private readonly IViolazioniService _violazioniService;

        public ViolazioniController(IViolazioniService violazioniService)
        {
            _violazioniService = violazioniService;
        }

        public async Task<IActionResult> Index() => View(await _violazioniService.GetViolazioniAsync());
    }
}