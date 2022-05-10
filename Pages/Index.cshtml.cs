using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LeapYearWebWithUser.Models;
using Microsoft.AspNetCore.Http;
using LeapYearWebWithUser.Data;
using Microsoft.EntityFrameworkCore;
using LeapYearWebWithUser.Interfaces;
using LeapYearWebWithUser.ViewModels.LeapYear;

namespace LeapYearWebWithUser.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ILeapYearService _leapYearService;

        [BindProperty]
        public LeapYear LeapYear { get; set; }

        public string[] Arr;

        public LeapYearListVM Records { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ILeapYearService leapYearService)
        {
            _leapYearService = leapYearService;
            _logger = logger;
        }

        public void OnGet()
        {
            Records = _leapYearService.GetEntriesFromToday();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                LeapYear.Date = DateTime.Now;
                LeapYear.User = User.Identity.Name;

                Arr = new string[4];
                Arr[0] = LeapYear.Name;
                Arr[1] = LeapYear.Surname;
                Arr[2] = LeapYear.Year.ToString();
                Arr[3] = LeapYear.IsLeapYear(LeapYear.Year);

                _leapYearService.AddEntry(LeapYear);
            }
            Records = _leapYearService.GetEntriesFromToday();
            return Page();
        }
    }
}