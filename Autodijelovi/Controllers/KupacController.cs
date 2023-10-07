using Autodijelovi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Autodijelovi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KupacController : ControllerBase
    {

        AutodijeloviContext db = new AutodijeloviContext();
       [HttpGet]
        public IActionResult sviKupci()
        {
            List<Kupac> podaci = db.Kupacs.OrderBy(r => r.IdKupca).ToList();
            return Ok(podaci);
        }


        [HttpPost]
        public IActionResult dodavanjeKupca([FromBody] Kupac noviKupac)
        {
            db.Add(noviKupac);
            db.SaveChanges();
            return Ok(noviKupac.IdKupca);
        }
    }
}
