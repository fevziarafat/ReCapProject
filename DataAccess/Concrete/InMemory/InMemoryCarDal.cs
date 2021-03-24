using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> cars = new List<Car> {
            new Car {BrandId = 1, ColorId = 1, DailyPrice = 1500, Description = "Temiz araba", Id = 1, ModelYear = 1999},
            new Car { BrandId = 1, ColorId = 2, DailyPrice = 2500, Description = "Temiz araba", Id = 2, ModelYear = 2002 },
            new Car {BrandId = 1, ColorId = 3, DailyPrice = 1000, Description = "Temiz araba", Id = 3, ModelYear = 1995},
            new Car { BrandId = 1, ColorId = 1, DailyPrice = 1900, Description = "Temiz araba", Id = 4, ModelYear = 2003 },

        };
        public Car GetById(Car car)
        {
            return cars.SingleOrDefault(p => p.Id == car.Id);
        }

        public List<Car> GetAll()
        {
            return cars;
        }


        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return cars;
        }

        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Update(Car car)
        {
            var addedCar = cars.SingleOrDefault(p => p.Id == car.Id);
            addedCar.ColorId = car.ColorId;
            addedCar.ModelYear = car.ModelYear;
            addedCar.DailyPrice = car.DailyPrice;
            addedCar.Description = car.Description;
            addedCar.BrandId = car.BrandId;
        }

        public void Delete(Car car)
        {
            var deletedCar = cars.SingleOrDefault(p => p.Id == car.Id);
            cars.Remove(deletedCar);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
