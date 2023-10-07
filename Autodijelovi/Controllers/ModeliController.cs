using Autodijelovi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Autodijelovi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ModeliController : ControllerBase
    {
        AutodijeloviContext db = new AutodijeloviContext();


        [HttpGet]
        public IActionResult sviModeli()
        {
            List<Modeli> podaci = db.Modelis.OrderBy(r => r.NazivModela).ToList();
            return Ok(podaci);
        }

        


    }
}
