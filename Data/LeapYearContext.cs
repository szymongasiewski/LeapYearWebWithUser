using Microsoft.EntityFrameworkCore;
using LeapYearWebWithUser.Models;

namespace LeapYearWebWithUser.Data
{
    public class LeapYearContext : DbContext
    {
        public LeapYearContext(DbContextOptions options) : base(options) { }
        public DbSet<LeapYear> LeapYear { get; set; }
    }
}