using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBengkel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JasaServisController : ControllerBase
    {
        static private List<JasaServis> jasaServis = new List<JasaServis>
        {
            new JasaServis
            {
              id_jasaServis = 1,
              nama_jasaServis = "Ringan",
              harga = 20000,
              keterangan = null
            },
            new JasaServis
            {
              id_jasaServis = 2,
              nama_jasaServis = "Sedang",
              harga = 35000,
              keterangan = null
            },
            new JasaServis
            {
              id_jasaServis = 4,
              nama_jasaServis = "berat",
              harga = 232,
              keterangan = "fasda"
            },
            new JasaServis
            {
              id_jasaServis = 5,
              nama_jasaServis = "promo akbar",
              harga = 10000,
              keterangan = "geratis motor"
            }
        };

        [HttpGet]
        public ActionResult<List<JasaServis>> GetjasaServis()
        {
            return Ok(jasaServis);
        }

    }
}
