namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    using Cars.Tests.JustMock.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CarsControllerTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new JustMockCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = null,
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = null,
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        public void SortCarsByMake()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual(4, model.Count);
            Assert.AreEqual("Audi", model.First().Make);
            Assert.AreEqual("Opel", model.Last().Make);
        }

        [TestMethod]
        public void SortCarsByYear()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(4, model.Count);
            Assert.AreEqual(2005, model.First().Year);
            Assert.AreEqual(2010, model.Last().Year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortCarsByInvalidParameter()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("wings"));
        }

        [TestMethod]
        public void GetByIdShouldReturnFirstCar()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(7));

            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetByIdWithNullCarShouldThrowException()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(0));
        }

        [TestMethod]
        public void NewInstanceOfCarsControllerWithoutRepository()
        {
            var controllerWithoutRepository = new CarsController();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SearchingNullShouldThrowException()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Search(null));
        }

        [TestMethod]
        public void SearchAnyCar()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Search("some car"));

            Assert.AreEqual(2, model.Count);
            Assert.AreEqual("BMW", model.First().Make);
            Assert.AreEqual("BMW", model.Last().Make);
            Assert.AreEqual("325i", model.First().Model);
            Assert.AreEqual("330d", model.Last().Model);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
