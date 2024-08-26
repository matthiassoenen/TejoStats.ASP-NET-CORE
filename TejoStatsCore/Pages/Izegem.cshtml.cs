using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Queries;
using System.Data;

namespace TejoStatsCore.Pages
{
    public class IzegemModel : PageModel
    {
        private readonly IStatsService _statsService2;

        public IzegemModel(IStatsService statsService)
        {
            _statsService2 = statsService;
        }

        public DataTable CountIntakes { get; set; }
        public DataTable CountIntakeType { get; set; }
        public DataTable CountGender { get; set; }
        public DataTable CountAge { get; set; }
        public DataTable CountCity { get; set; }
        public DataTable CountCountry { get; set; }
        public DataTable CountDoorverwijzer { get; set; }
        public DataTable CountDooverwezen { get; set; }
        public DataTable CountProblems { get; set; }
        public DataTable CountSchoolWerk { get; set; }
        public DataTable CountWoon { get; set; }
        public DataTable CountTherapeut { get; set; }
        public DataTable CountAanwezig { get; set; }
        public DataTable CountAfwezig { get; set; }
        public DataTable CountGemiddlede { get; set; }

        public async Task OnGetAsync(DateTime? startDateValue, DateTime? endDateValue, string huis)
        {
            // Zorg ervoor dat de datums en huis zijn ingesteld en niet null zijn
            if (startDateValue.HasValue && endDateValue.HasValue && !string.IsNullOrEmpty(huis))
            {
                CountIntakes = await _statsService2.CountIntakesAsync(startDateValue.Value, endDateValue.Value, huis);
                CountIntakeType = await _statsService2.CountIntakeTypeAsync(startDateValue.Value, endDateValue.Value, huis);
                CountGender = await _statsService2.CountGenderAsync(startDateValue.Value, endDateValue.Value, huis);
                CountAge = await _statsService2.CountAgeAsync(startDateValue.Value, endDateValue.Value, huis);
                CountCity = await _statsService2.CountCityAsync(startDateValue.Value, endDateValue.Value, huis);
                CountCountry = await _statsService2.CountCountryAsync(startDateValue.Value, endDateValue.Value, huis);
                CountDoorverwijzer = await _statsService2.CountDoorverwijzerAsync(startDateValue.Value, endDateValue.Value, huis);
                CountDooverwezen = await _statsService2.CountDoorverwezenAsync(startDateValue.Value, endDateValue.Value, huis);
                CountProblems = await _statsService2.CountProblemsAsync(startDateValue.Value, endDateValue.Value, huis);
                CountSchoolWerk = await _statsService2.CountSchoolWerkAsync(startDateValue.Value, endDateValue.Value, huis);
                CountWoon = await _statsService2.CountWoonAsync(startDateValue.Value, endDateValue.Value, huis);
                CountTherapeut = await _statsService2.CountTherapeutAsync(startDateValue.Value, endDateValue.Value, huis);
                CountAanwezig = await _statsService2.CountAanwezigAsync(startDateValue.Value, endDateValue.Value, huis);
                CountAfwezig = await _statsService2.CountAfwezigAsync(startDateValue.Value, endDateValue.Value, huis);
                CountGemiddlede = await _statsService2.CountGemiddeldeAsync(startDateValue.Value, endDateValue.Value, huis);
            }
        }
    }
}
