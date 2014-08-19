namespace Computers
{
    public class LaptopBattery
    {
        internal const int DefaultBatteryPercentage = 50;

        public LaptopBattery()
        {
            this.Percentage = DefaultBatteryPercentage;
        }

        internal int Percentage { get; set; }

        internal void Charge(int p)
        {
            this.Percentage += p;
            if (this.Percentage > 100)
            {
                this.Percentage = 100;
            }

            if (this.Percentage < 0)
            {
                this.Percentage = 0;
            }
        }
    }
}
