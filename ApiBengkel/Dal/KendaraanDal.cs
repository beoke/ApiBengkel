using ApiBengkel.Helper;
using ApiBengkel.Model;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ApiBengkel.Dal
{
    public class KendaraanDal
    {
        /* public async Task<IEnumerable<KendaraanModel>> ListKendaraanPelangganAsync(string ktp_pelanggan)
         {
             const string sql = @"
                     SELECT k.*, p.nama_pelanggan
                     FROM Kendaraan k 
                     INNER JOIN Pelanggan p ON k.ktp_pelanggan = p.ktp_pelanggan
                     WHERE k.ktp_pelanggan = @ktp_pelanggan";

             using var koneksi = new SqlConnection(Conn.connStr);
             return await koneksi.QueryAsync<KendaraanModel>(sql, new { ktp_pelanggan });
         }*/
        public async Task<IEnumerable<KendaraanModel>> ListKendaraanPelangganAsync(string ktp_pelanggan)
        {
            const string sql = @"
                    SELECT k.id_kendaraan, k.no_pol, k.merek, k.tipe, k.transmisi, k.kapasitas, k.tahun, p.nama_pelanggan
                    FROM Kendaraan k
                    INNER JOIN Pelanggan p ON k.ktp_pelanggan = p.ktp_pelanggan
                    WHERE k.ktp_pelanggan = @ktp_pelanggan";

            using var koneksi = new SqlConnection(Conn.connStr);
            try
            {
                return await koneksi.QueryAsync<KendaraanModel>(sql, new { ktp_pelanggan });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return Enumerable.Empty<KendaraanModel>(); // Mengembalikan list kosong jika terjadi error
            }
        }

    }
}
