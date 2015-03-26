namespace People
{
    public class Worker : Human
    {
        public Worker(string firstName, string lastName, decimal weekSalary, byte workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary { get; private set; }

        public byte WorkHoursPerDay { get; private set; }

        public decimal MoneyPerHour()
        {
            return (this.WeekSalary / 5) / this.WorkHoursPerDay;
        }
    }
}
