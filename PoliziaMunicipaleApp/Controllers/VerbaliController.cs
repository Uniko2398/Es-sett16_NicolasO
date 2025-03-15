using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipale.Models;
using PoliziaMunicipale.Services;
using PoliziaMunicipaleApp.Models;
using PoliziaMunicipaleApp.Services;
using System.Threading.Tasks;

namespace PoliziaMunicipaleApp.Controllers
{
    public class VerbaliController : Controller
    {
        private readonly IVerbaliService _verbaliService;
        private readonly IAnagraficheService _anagraficheService;
        private readonly IViolazioniService _violazioniService;

        public VerbaliController(IVerbaliService verbaliService, IAnagraficheService anagraficheService, IViolazioniService violazioniService)
        {
            _verbaliService = verbaliService;
            _anagraficheService = anagraficheService;
            _violazioniService = violazioniService;
        }

        public async Task<IActionResult> Index() => View(await _verbaliService.GetVerbaliAsync());

        public async Task<IActionResult> Create()
        {
            ViewBag.Anagrafiche = await _anagraficheService.GetAnagraficheAsync();
            ViewBag.Violazioni = await _violazioniService.GetViolazioniAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                await _verbaliService.AddVerbaleAsync(verbale);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Anagrafiche = await _anagraficheService.GetAnagraficheAsync();
            ViewBag.Violazioni = await _violazioniService.GetViolazioniAsync();
            return View(verbale);
        }
    }
}