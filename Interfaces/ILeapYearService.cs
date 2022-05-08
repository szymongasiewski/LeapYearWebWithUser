using LeapYearWebWithUser.Models;
using LeapYearWebWithUser.ViewModels.LeapYear;

namespace LeapYearWebWithUser.Interfaces
{
    public interface ILeapYearService
    {
        void AddEntry(LeapYear leapYear);
        LeapYearListVM GetAllEntries();
        LeapYearListVM GetEntriesFromToday();

        void RemoveRecord(int RecordId);
    }
}