namespace LeapYearWebWithUser.ViewModels.LeapYear
{
    public class LeapYearForListVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public int? Year { get; set; }
        public string IsLeapYear { get; set; }
        public string User { get; set; }
    }
}