using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Queries;
using System.Data;

namespace TejoStatsCore.Pages
{
    public class CompareModel : PageModel
    {
        private readonly IStatsCompareService _statsCompareService;

        public CompareModel(IStatsCompareService statsCompareService)
        {
            _statsCompareService = statsCompareService;
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
        public DataTable CountGemiddeldeWeken { get; set; }
        public DataTable CountGemiddeldeSessies { get; set; }

        public async Task OnGetAsync(DateTime? startDateValue, DateTime? endDateValue)
        {
            // Zorg ervoor dat de datums en huis zijn ingesteld en niet null zijn
            if (startDateValue.HasValue && endDateValue.HasValue)
            {
                CountIntakes = await _statsCompareService.CountIntakesAsync(startDateValue.Value, endDateValue.Value);
                CountIntakeType = await _statsCompareService.CountIntakeTypeAsync(startDateValue.Value, endDateValue.Value);
                CountGender = await _statsCompareService.CountGenderAsync(startDateValue.Value, endDateValue.Value);
                CountAge = await _statsCompareService.CountAgeAsync(startDateValue.Value, endDateValue.Value);
                CountCity = await _statsCompareService.CountCityAsync(startDateValue.Value, endDateValue.Value);
                CountCountry = await _statsCompareService.CountCountryAsync(startDateValue.Value, endDateValue.Value);
                CountDoorverwijzer = await _statsCompareService.CountDoorverwijzerAsync(startDateValue.Value, endDateValue.Value);
                CountDooverwezen = await _statsCompareService.CountDoorverwezenAsync(startDateValue.Value, endDateValue.Value);
                CountProblems = await _statsCompareService.CountProblemsAsync(startDateValue.Value, endDateValue.Value);
                CountSchoolWerk = await _statsCompareService.CountSchoolWerkAsync(startDateValue.Value, endDateValue.Value);
                CountWoon = await _statsCompareService.CountWoonAsync(startDateValue.Value, endDateValue.Value);
                CountAanwezig = await _statsCompareService.CountAanwezigAsync(startDateValue.Value, endDateValue.Value);
                CountAfwezig = await _statsCompareService.CountAfwezigAsync(startDateValue.Value, endDateValue.Value);
                CountGemiddeldeWeken = await _statsCompareService.CountGemiddeldeWekenAsync(startDateValue.Value, endDateValue.Value);
                CountGemiddeldeSessies = await _statsCompareService.CountGemiddeldeSessiesAsync(startDateValue.Value, endDateValue.Value);


            }
        }

    }
}