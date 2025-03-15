using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipale.Models;
using PoliziaMunicipale.Services;
using PoliziaMunicipaleApp.Models;
using PoliziaMunicipaleApp.Services;
using System.Threading.Tasks;

namespace PoliziaMunicipaleApp.Controllers
{
    public class AnagraficheController : Controller
    {
        private readonly IAnagraficheService _anagraficheService;

        public AnagraficheController(IAnagraficheService anagraficheService)
        {
            _anagraficheService = anagraficheService;
        }

        public async Task<IActionResult> Index() => View(await _anagraficheService.GetAnagraficheAsync());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                await _anagraficheService.AddAnagraficaAsync(anagrafica);
                return RedirectToAction(nameof(Index));
            }
            return View(anagrafica);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _anagraficheService.GetAnagraficaByIdAsync(id.Value);

            if (anagrafica == null)
            {
                return NotFound();
            }

            return View(anagrafica);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _anagraficheService.GetAnagraficaByIdAsync(id.Value);

            if (anagrafica == null)
            {
                return NotFound();
            }

            return View(anagrafica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Anagrafica anagrafica)
        {
            if (id != anagrafica.anagrafica_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _anagraficheService.UpdateAnagraficaAsync(anagrafica);
                return RedirectToAction(nameof(Index));
            }
            return View(anagrafica);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _anagraficheService.GetAnagraficaByIdAsync(id.Value);

            if (anagrafica == null)
            {
                return NotFound();
            }

            return View(anagrafica);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _anagraficheService.DeleteAnagraficaAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
