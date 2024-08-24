using System.Data;
using Microsoft.Data.SqlClient;

namespace Queries

{

    public interface IStatsService
    {
        Task<DataTable> CountIntakesAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> CountIntakeTypeAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> CountGenderAsync(DateTime startDate, DateTime endDate, string huis);
    }

    public class StatsService : IStatsService
    {
        private readonly string _connectionString;

        public StatsService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<DataTable> CountIntakesAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("CountIntakes", startDate, endDate, huis);
        }

        public async Task<DataTable> CountIntakeTypeAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("CountIntakeType", startDate, endDate, huis);
        }

        public async Task<DataTable> CountGenderAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("CountGender", startDate, endDate, huis);
        }

        private async Task<DataTable> GetDataTableFromStoredProcedureAsync(string storedProcedureName, DateTime startDate, DateTime endDate, string huis)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.Date) { Value = startDate });
                    command.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.Date) { Value = endDate });
                    command.Parameters.Add(new SqlParameter("@TejoHuis", SqlDbType.VarChar) { Value = huis });

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            return dataTable;
        }

    }
}
