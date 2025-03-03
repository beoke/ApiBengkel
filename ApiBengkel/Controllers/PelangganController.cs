using ApiBengkel.Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ApiBengkel.Model;

namespace ApiBengkel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PelangganController : ControllerBase
    {
        private readonly PelangganDal _pelangganDal;

        public PelangganController (PelangganDal pelangganDal)
        {
            _pelangganDal = pelangganDal;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel request)
        {
            if (request == null || string.IsNullOrEmpty(request.KtpPelanggan) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { message = "No KTP dan password harus diisi!" });
            }

            var pelanggan = await _pelangganDal.GetByKtpAndPasswordAsync(request.KtpPelanggan, request.Password);

            if (pelanggan == null)
            {
                return Unauthorized(new { message = "No KTP atau password salah!" });
            }

            return Ok(new
            {
                message = "Login berhasil",
                pelanggan.ktp_pelanggan,
                //pelanggan.email,
                pelanggan.nama_pelanggan
            });
        }
        // GET: Ambil data pelanggan berdasarkan No KTP dan Password
        [HttpGet("{ktp_pelanggan}/{password}")]
        public async Task<IActionResult> GetPelangganByKtpAndPassword(string ktp_pelanggan, string password)
        {
            var pelanggan = await _pelangganDal.GetByKtpAndPasswordAsync(ktp_pelanggan, password);

            if (pelanggan == null)
            {
                return NotFound(new { message = "Pelanggan tidak ditemukan atau password salah!" });
            }

            return Ok(pelanggan);
        }


    }

}
