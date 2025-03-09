using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ApiBengkel;
using ApiBengkel.Helper;

namespace ApiBengkel.Dal
{
    public class JasaServisDal
    {
        private IDbConnection CreateConnection() => new SqlConnection(Conn.connStr);

        // Mendapatkan semua data jasa servis
        public async Task<IEnumerable<JasaServisModel>> GetAllAsync()
        {
            using var connection = CreateConnection();
            string query = "SELECT * FROM JasaServis";
            return await connection.QueryAsync<JasaServisModel>(query);
        }

        // Mendapatkan data berdasarkan ID
        public async Task<JasaServisModel> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            string query = "SELECT * FROM JasaServis WHERE id_jasaServis = @Id";
            return await connection.QueryFirstOrDefaultAsync<JasaServisModel>(query, new { Id = id });
        }
    }
}
