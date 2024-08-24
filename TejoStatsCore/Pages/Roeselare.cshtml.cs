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

        public async Task OnGetAsync(DateTime? startDateValue, DateTime? endDateValue, string huis)
        {
            // Zorg ervoor dat de datums en huis zijn ingesteld en niet null zijn
            if (startDateValue.HasValue && endDateValue.HasValue && !string.IsNullOrEmpty(huis))
            {
                CountIntakes = await _statsService.CountIntakesAsync(startDateValue.Value, endDateValue.Value, huis);
                CountIntakeType = await _statsService.CountIntakeTypeAsync(startDateValue.Value, endDateValue.Value, huis);
                CountGender = await _statsService.CountGenderAsync(startDateValue.Value, endDateValue.Value, huis);
            }
        }

    }
}
