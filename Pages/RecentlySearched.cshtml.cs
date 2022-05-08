using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LeapYearWebWithUser.Data;
using LeapYearWebWithUser.Models;
using LeapYearWebWithUser.Interfaces;
using LeapYearWebWithUser.ViewModels.LeapYear;
using Microsoft.AspNetCore.Authorization;

namespace LeapYearWebWithUser.Pages
{
    [Authorize]
    public class RecentlySearchedModel : PageModel
    {
        private readonly ILeapYearService _leapYearService;
        public LeapYearListVM Records { get; set; }
        public IList<LeapYearForListVM> RecentlySearched { get; set; }

        public RecentlySearchedModel(ILeapYearService leapYearService)
        {
            _leapYearService = leapYearService;
        }

        public void OnGet()
        {
            Records = _leapYearService.GetAllEntries();
            RecentlySearched = Records.LeapYears.OrderByDescending(l => l.Date).Take(20).ToList();
        }

        public IActionResult OnPostDeleteRecord(int RecordId)
        {
            _leapYearService.RemoveRecord(RecordId);
            return RedirectToPage("./RecentlySearched");
        }
    }
}
