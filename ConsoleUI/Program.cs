using System;
using System.Linq;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ColorAdd();
            //var carManager = ListCar();
            //CarList(carManager);
            // NewMethod();
           // GetAll, GetById, Insert, Update, Delete.
           //BrandWork();
           ColorManager colorManager = new ColorManager(new EfColorDal());
           //colorManager.Add(new Color(){ColorName = "White"});
           //colorManager.Add(new Color() { ColorName = "White" });
           // colorManager.Update(new Color(){ColorName = "White - 2", Id = 5});
           // var allColor = colorManager.GetAll();
           // foreach (var color in allColor)
           // {
           //     Console.WriteLine(color.ColorName);
           // }

           // Console.WriteLine(colorManager.GetById(3).ColorName);
           CarManager carManager = new CarManager(new EfCarDal());
           carManager.Add(new Car(){CarName = "Mondeo",ColorId = 2,BrandId = 6,DailyPrice = 1500,Description = "Ford Mondeo",ModelYear = 1999});
           carManager.Add(new Car() { CarName = "Forester", ColorId = 1, BrandId = 3, DailyPrice = 1500, Description = "Subaru Forester", ModelYear = 1999 });
           carManager.Add(new Car() { CarName = "Laguna", ColorId = 3, BrandId = 10, DailyPrice = 1500, Description = "Renault Laguna", ModelYear = 1999 });
           var carlistBrand=carManager.GetCarsByBrandId(1);
           foreach (var car in carlistBrand)
           {
               Console.WriteLine(car.CarName);
           }

           var allCar=carManager.GetAll();
           foreach (var car in allCar)
           {
               Console.WriteLine(car.CarName);
           }

           var carDetails=carManager.GetCarDetails();
           foreach (var car in carDetails)
           {
               Console.WriteLine(car.BrandName+" --- "+  car.CarName + " --- " + car.ColorName + " --- " + car.DailyPrice);
           }
        }

        private static void BrandWork()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand() {BrandName = "Fiat"});
            brandManager.Add(new Brand() {BrandName = "Fiat - 2"});
            var brandalldata = brandManager.GetAll();
            foreach (var brand in brandalldata)
            {
                Console.WriteLine(brand.BrandName + " --- " + brand.Id);
            }

            brandManager.Delete(new Brand{BrandName = "Fiat",Id = 2});
            var brandalldata2 = brandManager.GetAll();
            foreach (var brand in brandalldata2)
            {
                Console.WriteLine(brand.BrandName + " --- " + brand.Id);
            }

            brandManager.Delete(brandalldata.SingleOrDefault(p => p.Id == 2));
        }

        private static void NewMethod()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(
                new Brand()
                {
                    BrandName = "Ford"
                });
            var databrand = brandManager.GetAll();
            foreach (var data in databrand)
            {
                Console.WriteLine(data.BrandName);
            }

            var databrandsize = brandManager.GetByLetterSize(p => p.BrandName.Length > 3);
            foreach (var data in databrandsize)
            {
                Console.WriteLine(data.BrandName);
            }
        }

        private static void CarList(CarManager carManager)
        {
            var carsbybrand = carManager.GetCarsByBrandId(1);
            foreach (var car in carsbybrand)
            {
                Console.WriteLine(car.CarName);
            }

            var carsbycolor = carManager.GetCarsByColorId(2);
            foreach (var car in carsbycolor)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static CarManager ListCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var item = carManager.GetAll();
            foreach (var car in item)
            {
                Console.WriteLine(car.Description);
            }

            return carManager;
        }

        private static void ColorAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color()
            {
                ColorName = "Purple",
            });
        }
    }
}
