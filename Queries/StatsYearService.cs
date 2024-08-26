using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Queries
{
    public interface IStatsYearService
    {
        #region BetweenDatesTable
        Task<DataTable> CountIntakesAsync(int year, string huis);
        Task<DataTable> CountIntakeTypeAsync(int year, string huis);
        Task<DataTable> CountGenderAsync(int year, string huis);
        Task<DataTable> CountAgeAsync(int year, string huis);
        Task<DataTable> CountCityAsync(int year, string huis);
        Task<DataTable> CountCountryAsync(int year, string huis);
        Task<DataTable> CountDoorverwijzerAsync(int year, string huis);
        Task<DataTable> CountDoorverwezenAsync(int year, string huis);
        Task<DataTable> CountProblemsAsync(int year, string huis);
        Task<DataTable> CountSchoolWerkAsync(int year, string huis);
        Task<DataTable> CountWoonAsync(int year, string huis);
        Task<DataTable> CountTherapeutAsync(int year, string huis);
        Task<DataTable> CountAanwezigAsync(int year, string huis);
        Task<DataTable> CountAfwezigAsync(int year, string huis);
        Task<DataTable> CountGemiddeldeAsync(int year, string huis);
        #endregion BetweenDatesTable


    }

    public class StatsYearService : IStatsYearService
    {
        private readonly string _connectionString;

        public StatsYearService(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region BetweenDatesQuery


        public async Task<DataTable> CountIntakesAsync(int year, string huis)
        {
            return await GetDataTableFromStoredProcedureYearAsync("CountIntakes",year, huis);
        }

        public async Task<DataTable> CountIntakeTypeAsync(int year, string huis)
        {
            return await GetDataTableFromStoredProcedureYearAsync("CountIntakeType", year, huis);
        }

        public async Task<DataTable> CountGenderAsync(int year, string huis)
        {
            return await GetDataTableFromStoredProcedureYearAsync("CountGender", year, huis);
        }

        public async Task<DataTable> CountAgeAsync(int year, string huis)
        {
            return await GetDataTableFromStoredProcedureYearAsync("CountAge", year, huis);
        }

        public async Task<DataTable> CountCityAsync(int year, string huis)
        {
            return await GetDataTableFromStoredProcedureYearAsync("CountCity", year, huis);
        }

        public async Task<DataTable> CountCountryAsync(int year, string huis)
        {
            return await GetDataTableFromStoredProcedureYearAsync("CountCountry", year, huis);
        }

        public async Task<DataTable> CountDoorverwijzerAsync(int year, string huis)
        {
            return await GetDataTableFromStoredProcedureYearAsync("CountDoorverwijzer", year, huis);
        }

        public async Task<DataTable> CountDoorverwezenAsync(int year, string huis)
        {
            return await GetDataTableFromStoredProcedureYearAsync("CountDoorverwezen", year, huis);
        }

        public async Task<DataTable> CountProblemsAsync(int year, string huis)
        {
            return await GetDataTableFromStoredProcedureYearAsync("CountProblems", year, huis);
        }

        public async Task<DataTable> CountSchoolWerkAsync(int year, string huis)
        {
            return await GetDataTableFromStoredProcedureYearAsync("CountSchoolWerk", year, huis);
        }

        public async Task<DataTable> CountWoonAsync(int year, string huis){
            return await GetDataTableFromStoredProcedureYearAsync("CountWoon", year, huis);
        }

        public async Task<DataTable> CountTherapeutAsync(int year, string huis)
        {
            return await GetDataTableFromStoredProcedureYearAsync("CountTherapeut", year, huis);
        }

        public async Task<DataTable> CountAanwezigAsync(int year, string huis)
        {
            return await GetDataTableFromStoredProcedureYearAsync("AanwezigeSessies", year, huis);
        }

        public async Task<DataTable> CountAfwezigAsync(int year, string huis)
        {
            return await GetDataTableFromStoredProcedureYearAsync("AfwezigeSessies", year, huis);
        }

        public async Task<DataTable> CountGemiddeldeAsync(int year, string huis)
        {
            return await GetDataTableFromStoredProcedureYearAsync("CountGemiddeldeAfgesloten", year, huis);
        }
        #endregion BetweenDatesQuery


        private async Task<DataTable> GetDataTableFromStoredProcedureYearAsync(string storedProcedureName, int year, string huis)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Bereken de start- en einddatums op basis van het jaar
                    DateTime startDate = new DateTime(year, 1, 1); // Begin van het jaar
                    DateTime endDate = new DateTime(year, 12, 31); // Eind van het jaar

                    // Voeg de parameters toe
                    command.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.Date) { Value = startDate });
                    command.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.Date) { Value = endDate });
                    command.Parameters.Add(new SqlParameter("@TejoHuis", SqlDbType.VarChar) { Value = huis });

                    // Open de verbinding en voer de stored procedure uit
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
