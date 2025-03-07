using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ApiBengkel;

namespace ApiBengkel.Dal
{
    public class PelangganDal
    {
        private readonly string _connectionString;

        public PelangganDal(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        // Mendapatkan semua data pelanggan
        public async Task<IEnumerable<PelangganModel>> GetAllAsync()
        {
            using var connection = CreateConnection();
            string query = "SELECT * FROM Pelanggan";
            return await connection.QueryAsync<PelangganModel>(query);
        }

        // Mendapatkan data berdasarkan KTP (varchar)
        public async Task<PelangganModel> GetByKtpAndPasswordAsync(string noKtp, string password)
        {
            using var connection = CreateConnection();
            string query = "SELECT * FROM Pelanggan WHERE ktp_pelanggan = @noKtp ";
            return await connection.QueryFirstOrDefaultAsync<PelangganModel>(query, new { noKtp, password });
        }
        public async Task<PelangganModel> GetByKtpAsync(string ktp_pelanggan)
        {
            var query = "SELECT * FROM Pelanggan WHERE ktp_pelanggan = @Ktp";
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<PelangganModel>(query, new { Ktp = ktp_pelanggan });
        }

    }
}
