using Autodijelovi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Autodijelovi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RadnjeController : ControllerBase
    {
        AutodijeloviContext db = new AutodijeloviContext();
        
        [HttpGet]
        public IActionResult sviGradovi()
        {
            List<Radnja> podaci = db.Radnjas.OrderBy(r => r.Grad).ToList();
            return Ok(podaci);
        }
    }
}
