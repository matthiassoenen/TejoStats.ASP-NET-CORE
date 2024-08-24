using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Queries;
using System.Data;

namespace TejoStatsCore.Pages
{

    public class RoeselareModel : PageModel
    {
        private readonly IStatsService _statsService;

        public RoeselareModel(IStatsService statsService)
        {
            _statsService = statsService;
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
                CountIntakes = await _statsService.CountIntakesAsync(startDateValue.Value, endDateValue.Value, huis);
                CountIntakeType = await _statsService.CountIntakeTypeAsync(startDateValue.Value, endDateValue.Value, huis);
                CountGender = await _statsService.CountGenderAsync(startDateValue.Value, endDateValue.Value, huis);
                CountAge = await _statsService.CountAgeAsync(startDateValue.Value, endDateValue.Value, huis);
                CountCity = await _statsService.CountCityAsync(startDateValue.Value, endDateValue.Value, huis);
                CountCountry = await _statsService.CountCountryAsync(startDateValue.Value, endDateValue.Value, huis);
                CountDoorverwijzer = await _statsService.CountDoorverwijzerAsync(startDateValue.Value, endDateValue.Value, huis);
                CountDooverwezen = await _statsService.CountDoorverwezenAsync(startDateValue.Value, endDateValue.Value, huis);
                CountProblems = await _statsService.CountProblemsAsync(startDateValue.Value, endDateValue.Value, huis);
                CountSchoolWerk = await _statsService.CountSchoolWerkAsync(startDateValue.Value, endDateValue.Value, huis);
                CountWoon = await _statsService.CountWoonAsync(startDateValue.Value, endDateValue.Value, huis);
                CountTherapeut = await _statsService.CountTherapeutAsync(startDateValue.Value, endDateValue.Value, huis);
                CountAanwezig = await _statsService.CountAanwezigAsync(startDateValue.Value, endDateValue.Value, huis);
                CountAfwezig = await _statsService.CountAfwezigAsync(startDateValue.Value, endDateValue.Value, huis);
                CountGemiddlede = await _statsService.CountGemiddeldeAsync(startDateValue.Value, endDateValue.Value, huis);
            }
        }

    }
}
