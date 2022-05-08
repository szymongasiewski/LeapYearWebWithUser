using LeapYearWebWithUser.Interfaces;
using LeapYearWebWithUser.Models;
using LeapYearWebWithUser.ViewModels.LeapYear;

namespace LeapYearWebWithUser.Services
{
    public class LeapYearService : ILeapYearService
    {
        private readonly ILeapYearRepository _leapYearRepo;

        public LeapYearService(ILeapYearRepository leapYearRepo)
        {
            _leapYearRepo = leapYearRepo;
        }

        public void AddEntry(LeapYear leapYear)
        {
            _leapYearRepo.AddLeapYear(leapYear);
        }

        public LeapYearListVM GetAllEntries()
        {
            LeapYearListVM result = new LeapYearListVM();
            result.LeapYears = new List<LeapYearForListVM>();

            foreach (var leapYear in _leapYearRepo.GetAllLeapYears())
            {
                var lYVM = new LeapYearForListVM()
                {
                    Id = leapYear.Id,
                    FullName = leapYear.Name + " " + leapYear.Surname,
                    Date = leapYear.Date,
                    Year = leapYear.Year,
                    IsLeapYear = leapYear.IsLeapYear(leapYear.Year) + "przestępny"
                };

                result.LeapYears.Add(lYVM);
            }

            return result;
        }

        public LeapYearListVM GetEntriesFromToday()
        {
            LeapYearListVM result = new LeapYearListVM();
            result.LeapYears = new List<LeapYearForListVM>();

            foreach (var leapYear in _leapYearRepo.GetAllLeapYears())
            {
                if (leapYear.Date.Date == DateTime.Today.Date)
                {
                    var lYVM = new LeapYearForListVM()
                    {
                        Id = leapYear.Id,
                        FullName = leapYear.Name + " " + leapYear.Surname,
                        Date = leapYear.Date,
                        Year = leapYear.Year,
                        IsLeapYear = leapYear.IsLeapYear(leapYear.Year) + "przestępny"
                    };

                    result.LeapYears.Add(lYVM);
                }
            }

            return result;
        }

        public void RemoveRecord(int RecordId)
        {
            _leapYearRepo.RemoveLeapYear(RecordId);
        }
    }
}