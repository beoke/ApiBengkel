using ApiBengkel.Dal;
using ApiBengkel.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiBengkel.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class SparepartController : ControllerBase
        {
            private readonly SparepartDal _sparepartDal;

            public SparepartController(SparepartDal sparepartDal)
            {
                _sparepartDal = sparepartDal;
            }

            // GET: api/Sparepart
            [HttpGet]
            public async Task<ActionResult<IEnumerable<SparepartModel>>> GetSparepart()
            {
                var spareparts = await _sparepartDal.GetAllAsync();
                return Ok(spareparts);
            }

            // GET: api/Sparepart/{id}
            [HttpGet("{id}")]
            public async Task<ActionResult<SparepartModel>> GetSparepartById(int id)
            {
                var sparepart = await _sparepartDal.GetByIdAsync(id);
                if (sparepart == null)
                    return NotFound("Sparepart tidak ditemukan.");
                return Ok(sparepart);
            }
        }
}
