using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public class Driver
    {
        private SportsCar sportsCar;
        private FamilyCar familyCar;

        public Driver(CarFactory carFactory)
        {
            sportsCar = carFactory.CreateSportsCar();
            familyCar = carFactory.CreateFamilyCar();
        }

        public void CompareSpeed()
        {
            familyCar.Speed(sportsCar);
        }
    }
}
