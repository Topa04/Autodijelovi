using Autodijelovi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Autodijelovi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ModRadController : ControllerBase
    {

        AutodijeloviContext db = new AutodijeloviContext();



        [HttpPost]
        public IActionResult traziDijelove([FromBody] proslijedeniObjekat filter)
        {
               var lista = (from v in db.ModeliRadnjas
                            from d in db.Dijelovis.Where(x => x.IdDijela == v.IdDijela).DefaultIfEmpty()
                            from m in db.Modelis.Where(x => x.IdModela == v.IdModela).DefaultIfEmpty()
                            from r in db.Radnjas.Where(x => x.IdRadnje == v.IdRadnje).DefaultIfEmpty()
                            select new
                            {
                                id_veze=v.IdVeze,
                                naziv_Dijela = d.Naziv,
                                naziv_Modela = m.NazivModela,
                                cijena = d.Cijena,
                                radnja = r.NazivRadnje,
                                grad = r.Grad
                            }).ToList();
            
            if(filter.grad == "0" && filter.model == "0" && filter.dio == "0")
            {
                return Ok(lista);
            }
            else if (filter.grad == "0" && filter.dio == "0" && filter.model != "0")
            {
                return Ok(lista.Where(x => x.naziv_Modela == filter.model));
            }
            else if (filter.grad == "0" && filter.model != "0" && filter.dio != "0")
            {
                return Ok(lista.Where(x => x.naziv_Dijela == filter.dio && x.naziv_Modela == filter.model));
            }else if (filter.grad != "0" && filter.model != "0" && filter.dio != "0")
            {
                return Ok(lista.Where(x => x.naziv_Dijela == filter.dio && x.naziv_Modela == filter.model && x.grad == filter.grad));
            }
            return Ok();
                
        }

        public class proslijedeniObjekat
        {
            public string grad { get; set; }
            public string model { get; set; }
            public string dio { get; set; }
        }

    }
}

