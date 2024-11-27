using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace TaskApp.Services.Library
{

    public class DAO
    {
        private readonly string _connectionString;

        public DAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<T>(sql, parameters);
            }
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QuerySingleOrDefaultAsync<T>(sql, parameters);
            }
        }

        public async Task<int> ExecuteAsync(string sql, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.ExecuteScalarAsync<T>(sql, parameters);
            }
        }

        public async Task<IEnumerable<T>> ExecuteStoredProcedureAsync<T>(string storedProcedure, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

