using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBengkel.Dal;
using ApiBengkel;

namespace ApiBengkel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JasaServisController : ControllerBase
    {
        private readonly JasaServisDal _jasaServisDal;

        public JasaServisController(JasaServisDal jasaServisDal)
        {
            _jasaServisDal = jasaServisDal;
        }

        // GET: api/JasaServis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JasaServisModel>>> GetJasaServis()
        {
            var jasaServis = await _jasaServisDal.GetAllAsync();
            return Ok(jasaServis);
        }

        // GET: api/JasaServis/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<JasaServisModel>> GetJasaServisById(int id)
        {
            var jasa = await _jasaServisDal.GetByIdAsync(id);
            if (jasa == null)
                return NotFound("Jasa servis tidak ditemukan.");
            return Ok(jasa);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetJasaServisName(int id)
        {
            var jasaServisName = await _jasaServisDal.GetJasaServisNameByIdAsync(id);
            if (jasaServisName == null)
                return NotFound("Jasa servis tidak ditemukan.");

            return Ok(jasaServisName);
        }
    }
}
