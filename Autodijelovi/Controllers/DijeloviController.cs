using Autodijelovi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Autodijelovi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DijeloviController : ControllerBase
    {
        AutodijeloviContext db = new AutodijeloviContext();
        
        [HttpGet]
        public IActionResult sviDijelovi()
        {
            List<Dijelovi> podaci = db.Dijelovis.OrderBy(r => r.IdDijela).ToList();
            return Ok(podaci);
        }

        [HttpGet]
        public IActionResult prikaz()
        {
            var lista = (from v in db.ModeliRadnjas
                         from d in db.Dijelovis.Where(x => x.IdDijela == v.IdDijela).DefaultIfEmpty()
                         from m in db.Modelis.Where(x => x.IdModela == v.IdModela).DefaultIfEmpty()
                         from r in db.Radnjas.Where(x => x.IdRadnje == v.IdRadnje).DefaultIfEmpty()
                         select new
                         {
                             id_veze = v.IdVeze,
                             naziv_Dijela = d.Naziv,
                             naziv_Modela = m.NazivModela,
                             cijena = d.Cijena,
                             radnja = r.NazivRadnje,
                             grad = r.Grad
                         }).ToList();
            return Ok(lista);
        }

        [HttpPost]
        public IActionResult dodavanjeDijela([FromBody] Dijelovi noviDio)
        {
            db.Add(noviDio);
            db.SaveChanges();
            return Ok(noviDio.IdDijela);
        }

        [HttpGet]
        public IActionResult getLastID()
        {
            List<Dijelovi> podaci = db.Dijelovis.OrderBy(r => r.IdDijela).ToList();
            var id = podaci.Count + 1000;
            return Ok(id);
        }


        [HttpDelete("{param:int}")]
        public IActionResult obrisiDio(int param)
        {
            Dijelovi rezultat = db.Dijelovis.Where(a => a.IdDijela == param).FirstOrDefault();
            if (rezultat == null)
            {
                return NotFound($"Podatak sa ID = {param} nije pronadjen");
            }
            else
            {
                db.Remove(rezultat);
                db.SaveChanges();
            }
            return Ok("Obrisano");
        }

        [HttpGet("{id:int}")]
        public IActionResult pronadjiDio(int id)
        {
            Dijelovi rezultat = db.Dijelovis.Where(a => a.IdDijela == id).FirstOrDefault();
            return Ok(rezultat);

        }

        [HttpPost]
        public IActionResult azurirajDio([FromBody] Dijelovi azuriraniDio)
        {
            Dijelovi rezultat = db.Dijelovis.Where(a => a.IdDijela == azuriraniDio.IdDijela).FirstOrDefault();
            if (rezultat != null)
            {
                rezultat.Sifra = (azuriraniDio.Sifra != null) ? azuriraniDio.Sifra : rezultat.Sifra;
                rezultat.Naziv = (azuriraniDio.Naziv != null) ? azuriraniDio.Naziv : rezultat.Naziv;
                rezultat.Proizvodac = (azuriraniDio.Proizvodac != null) ? azuriraniDio.Proizvodac : rezultat.Proizvodac;
                rezultat.Cijena = (azuriraniDio.Cijena != null) ? azuriraniDio.Cijena : rezultat.Cijena;

                db.SaveChanges();
            }
            else
            {
                return NotFound($"Osoba sa id {azuriraniDio.IdDijela} nije pronadjena");
            }

            return Ok(rezultat);
        }
    }
}
