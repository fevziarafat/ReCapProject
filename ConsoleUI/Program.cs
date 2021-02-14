using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ColorManager colorManager = new ColorManager(new InMemoryColorDal());
            colorManager.Add(new Color()
            {
                ColorName = "Purple",Id = 6
            });
            CarManager carManager = new CarManager(new InMemoryCarDal());
            var item=carManager.GetAll();
            foreach (var car in item)
            {
                Console.WriteLine(car.Description);
            }
            
        }
    }
}
