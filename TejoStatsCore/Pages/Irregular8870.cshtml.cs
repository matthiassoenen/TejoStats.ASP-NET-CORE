using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Queries;
using System.Data;

namespace TejoStatsCore.Pages
{
    public class Irregular8870Model : PageModel
    {
        private readonly IStatsService _statsService;

        public Irregular8870Model(IStatsService statsService)
        {
            _statsService = statsService;
        }

        public DataTable CountMissingFiles { get; set; }
        public DataTable NoProblems { get; set; }
        public DataTable WrongRegistration { get; set; }
        public DataTable NoDoorverwezen { get; set; }
        public DataTable CountWrongRegistration { get; set; }



        public async Task OnGetAsync(DateTime? startDateValue, DateTime? endDateValue, string huis)
        {
            // Zorg ervoor dat de datums en huis zijn ingesteld en niet null zijn
            if (startDateValue.HasValue && endDateValue.HasValue && !string.IsNullOrEmpty(huis))
            {
                CountMissingFiles = await _statsService.CountMissingFilesAsync(startDateValue.Value, endDateValue.Value, huis);
                NoProblems = await _statsService.NoProblemsAsync(startDateValue.Value, endDateValue.Value, huis);
                WrongRegistration = await _statsService.WrongRegistrationAsync(startDateValue.Value, endDateValue.Value, huis);
                NoDoorverwezen = await _statsService.NoDoorverwezenAsync(startDateValue.Value, endDateValue.Value, huis);
                CountWrongRegistration = await _statsService.CountWrongRegistrationAsync(startDateValue.Value, endDateValue.Value, huis);
            }
        }

    }
}