using LeapYearWebWithUser.Models;

namespace LeapYearWebWithUser.Interfaces
{
    public interface ILeapYearRepository
    {
        IQueryable<LeapYear> GetAllLeapYears();

        void AddLeapYear(LeapYear leapYear);

        void RemoveLeapYear(int RecordId);
    }
}