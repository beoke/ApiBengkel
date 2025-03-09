using ApiBengkel.Helper;
using ApiBengkel.Model;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ApiBengkel.Dal
{
    public class KendaraanDal
    {
        public IEnumerable<KendaraanModel> ListDataPelanggan(string ktp_pelanggan)
        {
            const string sql = @"SELECT k.*,p.nama_pelanggan
                                FROM Kendaraan k 
                                INNER JOIN Pelanggan p
                                    ON k.ktp_pelanggan = p.ktp_pelanggan
                                WHERE k.ktp_pelanggan = @ktp_pelanggan";
            using var koneksi = new SqlConnection(Conn.connStr);
            return koneksi.Query<KendaraanModel>(sql, new { ktp_pelanggan = ktp_pelanggan });
        }
    }
}
