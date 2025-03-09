using ApiBengkel.Dal;
using ApiBengkel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBengkel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KendaraanController : ControllerBase
    {
        private readonly KendaraanDal _kendaraanDal;

        public KendaraanController(KendaraanDal kendaraanDal)
        {
            _kendaraanDal = kendaraanDal;
        }
        [HttpGet("kendaraan/{ktp_pelanggan}")]
        public async Task<IActionResult> GetKendaraanByPelanggan(string ktp_pelanggan)
        {
            var kendaraanList = await _kendaraanDal.ListKendaraanPelangganAsync(ktp_pelanggan);

            if (kendaraanList == null || !kendaraanList.Any())
            {
                return NotFound(new { message = "Tidak ada kendaraan ditemukan untuk pelanggan ini." });
            }

            return Ok(kendaraanList);
        }

    }
}
