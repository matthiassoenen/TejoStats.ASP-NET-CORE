using System.Data;
using Microsoft.Data.SqlClient;

namespace Queries

{

    public interface IStatsService
    {
        #region BetweenDatesTable
        Task<DataTable> CountIntakesAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> CountIntakeTypeAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> CountGenderAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> CountAgeAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> CountCityAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> CountCountryAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> CountDoorverwijzerAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> CountDoorverwezenAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> CountProblemsAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> CountSchoolWerkAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> CountWoonAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> CountTherapeutAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> CountAanwezigAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> CountAfwezigAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> CountGemiddeldeAsync(DateTime startDate, DateTime endDate, string huis);
        #endregion BetweenDatesTable

        #region IrregularTable
        Task<DataTable> CountMissingFilesAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> NoProblemsAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> WrongRegistrationAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> NoDoorverwezenAsync(DateTime startDate, DateTime endDate, string huis);
        Task<DataTable> CountWrongRegistrationAsync(DateTime startDate, DateTime endDate, string huis);
        #endregion IrregularTable
    }



    public class StatsService : IStatsService
    {
        private readonly string _connectionString;

        public StatsService(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region BetweenDatesQuery

        
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

        public async Task<DataTable> CountAgeAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("CountAge", startDate, endDate, huis);
        }

        public async Task<DataTable> CountCityAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("CountCity", startDate, endDate, huis);
        }

        public async Task<DataTable> CountCountryAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("CountCountry", startDate, endDate, huis);
        }

        public async Task<DataTable> CountDoorverwijzerAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("CountDoorverwijzer", startDate, endDate, huis);
        }

        public async Task<DataTable> CountDoorverwezenAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("CountDoorverwezen", startDate, endDate, huis);
        }

        public async Task<DataTable> CountProblemsAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("CountProblems", startDate, endDate, huis);
        }

        public async Task<DataTable> CountSchoolWerkAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("CountSchoolWerk", startDate, endDate, huis);
        }

        public async Task<DataTable> CountWoonAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("CountWoon", startDate, endDate, huis);
        }

        public async Task<DataTable> CountTherapeutAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("CountTherapeut", startDate, endDate, huis);
        }

        public async Task<DataTable> CountAanwezigAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("AanwezigeSessies", startDate, endDate, huis);
        }

        public async Task<DataTable> CountAfwezigAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("AfwezigeSessies", startDate, endDate, huis);
        }

        public async Task<DataTable> CountGemiddeldeAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("CountGemiddeldeAfgesloten", startDate, endDate, huis);
        }
        #endregion BetweenDatesQuery

        #region IrregularQuery
        public async Task<DataTable> NoProblemsAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("_NoProblem", startDate, endDate, huis);
        }

        public async Task<DataTable> CountMissingFilesAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("MissingFiles", startDate, endDate, huis);
        }

        public async Task<DataTable> WrongRegistrationAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("_NoRegisteredSessions", startDate, endDate, huis);
        }

        public async Task<DataTable> NoDoorverwezenAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("_NoDoorverwezenNaar", startDate, endDate, huis);
        }

        public async Task<DataTable> CountWrongRegistrationAsync(DateTime startDate, DateTime endDate, string huis)
        {
            return await GetDataTableFromStoredProcedureAsync("_CountNotSessions", startDate, endDate, huis);
        }
        #endregion IrregularQuery

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