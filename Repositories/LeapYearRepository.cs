using LeapYearWebWithUser.Interfaces;
using LeapYearWebWithUser.Models;
using LeapYearWebWithUser.Data;

namespace LeapYearWebWithUser.Repositories
{
    public class LeapYearRepository : ILeapYearRepository
    {
        private readonly LeapYearContext _context;

        public LeapYearRepository(LeapYearContext context)
        {
            _context = context;
        }

        public IQueryable<LeapYear> GetAllLeapYears()
        {
            return _context.LeapYear;
        }

        public void AddLeapYear(LeapYear leapYear)
        {
            _context.LeapYear.Add(leapYear);
            _context.SaveChanges();
        }

        public void RemoveLeapYear(int RecordId)
        {
            _context.Remove(_context.LeapYear.Single(l => l.Id == RecordId));
            _context.SaveChanges();
        }
    }
}