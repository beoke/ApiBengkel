using ApiBengkel.Helper;
using ApiBengkel.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiBengkel.Dal
{
    public class SparepartDal
    {
        private IDbConnection CreateConnection() => new SqlConnection(Conn.connStr);

        public async Task<IEnumerable<SparepartModel>> GetAllAsync()
        {
            using var connection = CreateConnection();
            string query = "SELECT * FROM Sparepart     ";
            return await connection.QueryAsync<SparepartModel>(query);
        }
        // Mendapatkan data berdasarkan ID
        public async Task<SparepartModel> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            string query = "SELECT * FROM Sparepart WHERE kode_sparepart = @Kode";
            return await connection.QueryFirstOrDefaultAsync<SparepartModel>(query, new { Id = id });
        }
    }
}
