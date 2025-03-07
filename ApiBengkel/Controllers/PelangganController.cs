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
            if (request == null || string.IsNullOrEmpty(request.ktp_pelanggan) || string.IsNullOrEmpty(request.password))
            {
                return BadRequest(new { success = false, message = "No KTP dan password harus diisi!" });
            }

            var pelanggan = await _pelangganDal.GetByKtpAndPasswordAsync(request.ktp_pelanggan, request.password);

            if (pelanggan == null)
            {
                return Unauthorized(new { success = false, message = "No KTP atau password salah!" });
            }

            return Ok(new
            {
                success = true,
              //  message = "Login berhasil",
                pelanggan.ktp_pelanggan,
                pelanggan.nama_pelanggan,
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

        // GET: Ambil seluruh data pelanggan berdasarkan No KTP
        [HttpGet("profile/{ktp_pelanggan}")]
        public async Task<IActionResult> GetPelangganProfile(string ktp_pelanggan)
        {
            var pelanggan = await _pelangganDal.GetByKtpAsync(ktp_pelanggan);

            if (pelanggan == null)
            {
                return NotFound(new { message = "Pelanggan tidak ditemukan!" });
            }

            return Ok(pelanggan);
        }


    }

}
