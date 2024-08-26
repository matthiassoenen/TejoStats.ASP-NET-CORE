using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Queries;
using System.Data;

namespace TejoStatsCore.Pages
{
    public class PerJaar8870Model : PageModel
    {
        private readonly IStatsYearService _statsService;

        public PerJaar8870Model(IStatsYearService statsService)
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

        public async Task OnGetAsync(int year, string huis)
        {
            // Zorg ervoor dat de datums en huis zijn ingesteld en niet null zijn
            if (!string.IsNullOrEmpty(huis))
            {
                CountIntakes = await _statsService.CountIntakesAsync(year, huis);
                CountIntakeType = await _statsService.CountIntakeTypeAsync(year, huis);
                CountGender = await _statsService.CountGenderAsync(year, huis);
                CountAge = await _statsService.CountAgeAsync(year, huis);
                CountCity = await _statsService.CountCityAsync(year, huis);
                CountCountry = await _statsService.CountCountryAsync(year, huis);
                CountDoorverwijzer = await _statsService.CountDoorverwijzerAsync(year, huis);
                CountDooverwezen = await _statsService.CountDoorverwezenAsync(year, huis);
                CountProblems = await _statsService.CountProblemsAsync(year, huis);
                CountSchoolWerk = await _statsService.CountSchoolWerkAsync(year, huis);
                CountWoon = await _statsService.CountWoonAsync(year, huis);
                CountTherapeut = await _statsService.CountTherapeutAsync(year, huis);
                CountAanwezig = await _statsService.CountAanwezigAsync(year, huis);
                CountAfwezig = await _statsService.CountAfwezigAsync(year, huis);
                CountGemiddlede = await _statsService.CountGemiddeldeAsync(year, huis);
            }
        }
    }
}
