using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    public interface IStatsCompareService
    {
        #region BetweenDatesTable

        Task<DataTable> CountIntakesAsync(DateTime startDate, DateTime endDate);
        Task<DataTable> CountIntakeTypeAsync(DateTime startDate, DateTime endDate);
        Task<DataTable> CountGenderAsync(DateTime startDate, DateTime endDate);
        Task<DataTable> CountAgeAsync(DateTime startDate, DateTime endDate);
        Task<DataTable> CountCityAsync(DateTime startDate, DateTime endDate);
        Task<DataTable> CountCountryAsync(DateTime startDate, DateTime endDate);
        Task<DataTable> CountDoorverwijzerAsync(DateTime startDate, DateTime endDate);
        Task<DataTable> CountDoorverwezenAsync(DateTime startDate, DateTime endDate);
        Task<DataTable> CountProblemsAsync(DateTime startDate, DateTime endDate);
        Task<DataTable> CountSchoolWerkAsync(DateTime startDate, DateTime endDate);
        Task<DataTable> CountWoonAsync(DateTime startDate, DateTime endDate);
        //Task<DataTable> CountTherapeutAsync(DateTime startDate, DateTime endDate);
        Task<DataTable> CountAanwezigAsync(DateTime startDate, DateTime endDate);
        Task<DataTable> CountAfwezigAsync(DateTime startDate, DateTime endDate);

        Task<DataTable> CountGemiddeldeWekenAsync(DateTime startDate, DateTime endDate);
        Task<DataTable> CountGemiddeldeSessiesAsync(DateTime startDate, DateTime endDate);

        #endregion BetweenDatesTable
    }

    public class StatsCompareService : IStatsCompareService
    {
        private readonly string _connectionString;

        public StatsCompareService(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region BetweenDatesQuery

        public async Task<DataTable> CountIntakesAsync(DateTime startDate, DateTime endDate)
        {
            return await GetDataTableFromStoredProcedureAsync("PivotCountIntakes", startDate, endDate);
        }

        public async Task<DataTable> CountIntakeTypeAsync(DateTime startDate, DateTime endDate)
        {
            return await GetDataTableFromStoredProcedureAsync("PivotCountIntakeType", startDate, endDate);
        }

        public async Task<DataTable> CountGenderAsync(DateTime startDate, DateTime endDate)
        {
            return await GetDataTableFromStoredProcedureAsync("PivotCountGender", startDate, endDate);
        }

        public async Task<DataTable> CountAgeAsync(DateTime startDate, DateTime endDate)
        {
            return await GetDataTableFromStoredProcedureAsync("PivotCountAge", startDate, endDate);
        }

        public async Task<DataTable> CountCityAsync(DateTime startDate, DateTime endDate)
        {
            return await GetDataTableFromStoredProcedureAsync("PivotCountCity", startDate, endDate);
        }

        public async Task<DataTable> CountCountryAsync(DateTime startDate, DateTime endDate)
        {
            return await GetDataTableFromStoredProcedureAsync("PivotCountCountry", startDate, endDate);
        }

        public async Task<DataTable> CountDoorverwijzerAsync(DateTime startDate, DateTime endDate)
        {
            return await GetDataTableFromStoredProcedureAsync("PivotCountDoorverwijzer", startDate, endDate);
        }

        public async Task<DataTable> CountDoorverwezenAsync(DateTime startDate, DateTime endDate)
        {
            return await GetDataTableFromStoredProcedureAsync("PivotCountDoorverwezen", startDate, endDate);
        }

        public async Task<DataTable> CountProblemsAsync(DateTime startDate, DateTime endDate)
        {
            return await GetDataTableFromStoredProcedureAsync("PivotCountProblems", startDate, endDate);
        }

        public async Task<DataTable> CountSchoolWerkAsync(DateTime startDate, DateTime endDate)
        {
            return await GetDataTableFromStoredProcedureAsync("PivotCountSchoolWerk", startDate, endDate);
        }

        public async Task<DataTable> CountWoonAsync(DateTime startDate, DateTime endDate)
        {
            return await GetDataTableFromStoredProcedureAsync("PivotCountWoon", startDate, endDate);
        }

        public async Task<DataTable> CountGemiddeldeWekenAsync(DateTime startDate, DateTime endDate)
        {
            return await GetDataTableFromStoredProcedureAsync("PivotCountGemiddeldeWeken", startDate, endDate);
        }

        public async Task<DataTable> CountGemiddeldeSessiesAsync(DateTime startDate, DateTime endDate)
        {
            return await GetDataTableFromStoredProcedureAsync("PivotCountGemiddeldeSessies", startDate, endDate);
        }

        public async Task<DataTable> CountAanwezigAsync(DateTime startDate, DateTime endDate)
        {
            return await GetDataTableFromStoredProcedureAsync("PivotAanwezigeSessies", startDate, endDate);
        }

        public async Task<DataTable> CountAfwezigAsync(DateTime startDate, DateTime endDate)
        {
            return await GetDataTableFromStoredProcedureAsync("PivotAfwezigeSessies", startDate, endDate);
        }
        #endregion


        private async Task<DataTable> GetDataTableFromStoredProcedureAsync(string storedProcedureName,
            DateTime startDate, DateTime endDate)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.Date) { Value = startDate });
                    command.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.Date) { Value = endDate });
                    // command.Parameters.Add(new SqlParameter("@TejoHuis", SqlDbType.VarChar) { Value = huis });

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
