using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PoliziaMunicipale.Controllers
{
    public class ReportController : Controller
    {
        public async Task<IActionResult> TotaleVerbaliPerAnagrafe()
        {
            var report = await _context.Tipo_Verbali
                .Include(v => v.Trasgressore)
                .GroupBy(v => v.TrasgressoreId)
                .Select(g => new
                {
                    Trasgressore = g.First().Trasgressore.Cognome + " " + g.First().Trasgressore.Nome,
                    TotaleVerbali = g.Count()
                })
                .ToListAsync();
            return View(report);
        }

        public async Task<IActionResult> TotalePuntiDecurtatiPerTrasgressore()
        {
            var report = await _context.Verbali
                .Include(v => v.Trasgressore)
                .GroupBy(v => v.TrasgressoreId)
                .Select(g => new
                {
                    Trasgressore = g.First().Trasgressore.Cognome + " " + g.First().Trasgressore.Nome,
                    TotalePuntiDecurtati = g.Sum(v => v.PuntiDecurtati)
                })
                .ToListAsync();
            return View(report);
        }

        public async Task<IActionResult> ViolazioniOltre10Punti()
        {
            var report = await _context.Verbali
                .Include(v => v.Trasgressore)
                .Where(v => v.PuntiDecurtati > 10)
                .Select(v => new
                {
                    v.Importo,
                    Cognome = v.Trasgressore.Cognome,
                    Nome = v.Trasgressore.Nome,
                    v.DataViolazione,
                    v.PuntiDecurtati
                })
                .ToListAsync();
            return View(report);
        }
    }
}
