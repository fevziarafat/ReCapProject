namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //UserManagerEkleme();
           // CustomerManagerTest();
           //RentalManager rentalManager = new RentalManager(new EfRentalDal());
           //rentalManager.Add(new Rental() {CarId = 2, CustomerId = 1
           // });


           //var data = rentalManager.GetAll();
           ////Console.WriteLine(data.Data.Add(""));
           // foreach (var dataRental in data.Data)
            //{
            //    Console.WriteLine(dataRental.RentDate + "  --  "
            //                                         + dataRental.CustomerId + "  --  " + dataRental.Id
            //                                         + "  --  " + dataRental.ReturnDate);
            //}


            //ColorAdd();
            //var carManager = ListCar();
            //CarList(carManager);
            // NewMethod();
            // GetAll, GetById, Insert, Update, Delete.
            //BrandWork();
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color(){ColorName = "White"});
            //colorManager.Add(new Color() { ColorName = "White" });
            // colorManager.Update(new Color(){ColorName = "White - 2", Id = 5});
            // var allColor = colorManager.GetAll();
            // foreach (var color in allColor)
            // {
            //     Console.WriteLine(color.ColorName);
            // }

            // Console.WriteLine(colorManager.GetById(3).ColorName);
            //CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car(){CarName = "Mondeo",ColorId = 2,BrandId = 6,DailyPrice = 1500,Description = "Ford Mondeo",ModelYear = 1999});
            //carManager.Add(new Car() { CarName = "Forester", ColorId = 1, BrandId = 3, DailyPrice = 1500, Description = "Subaru Forester", ModelYear = 1999 });
            //carManager.Add(new Car() { CarName = "Laguna", ColorId = 3, BrandId = 10, DailyPrice = 1500, Description = "Renault Laguna", ModelYear = 1999 });
            //var carlistBrand=carManager.GetCarsByBrandId(1);
            //if (carlistBrand.Success)
            //{
            //    foreach (var car in carlistBrand.Data)
            //    {
            //        Console.WriteLine(car.CarName);
            //    }
            // }
            //else
            //{
            //    Console.WriteLine(carlistBrand.Message);
            //}


            //var allCar=carManager.GetAll();
            //if (allCar.Success)
            //{
            //    foreach (var car in allCar.Data)
            //    {
            //        Console.WriteLine(car.CarName);
            //    }
            // }
            //else
            //{
            //    Console.WriteLine(allCar.Message);
            //}


            //var carDetails=carManager.GetCarDetails();
            //if (carDetails.Success)
            //{
            //    foreach (var car in carDetails.Data)
            //    {
            //        Console.WriteLine(car.BrandName + " --- " +
            //                          car.CarName + " --- " +
            //                          car.ColorName + " --- " + car.DailyPrice);
            //    }
            // }
            //else
            //{
            //    Console.WriteLine(carDetails.Message);
            //}
        }

        //private static void CustomerManagerTest()
        //{
        //    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        //    customerManager.Add(new Customer() {Adress = "Şenyurt Mahallesi", CompanyName = "Şenyurt", UserId = 1});
        //    var customerDataResult = customerManager.GetAll();
        //    foreach (var cust in customerDataResult.Data)
        //    {
        //        Console.WriteLine(cust.CompanyName);
        //        Console.WriteLine(cust.Adress);
        //        Console.WriteLine(cust.UserId);
        //    }
        //}

        //private static void UserManagerEkleme()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    //userManager.Add(new User()
        //    //    {Email = "emre@emre.com", FirstName = "Emre", LastName = "Emre Soyadı", Password = "emre"});
        //    var userData = userManager.GetAll();
        //    foreach (var user in userData.Data)
        //    {
        //        Console.WriteLine(user.Id);
        //        Console.WriteLine(user.FirstName);
        //        Console.WriteLine(user.LastName);
        //        Console.WriteLine(user.Email);
        //    }

        //    //Console.WriteLine("------------------ekleme listeleme yapıldı--------------");
        //    //userManager.Update(new User()
        //    //    {Email = "e@e.com", FirstName = "Emre", LastName = "Emre Soyadı", Password = "emre", Id = 1});
        //    //Console.WriteLine("------------------Düzeltme listeleme yapıldı--------------");
        //    //var userData2 = userManager.GetAll();
        //    //foreach (var user in userData2.Data)
        //    //{
        //    //    Console.WriteLine(user.Id);
        //    //    Console.WriteLine(user.FirstName);
        //    //    Console.WriteLine(user.LastName);
        //    //    Console.WriteLine(user.Email);
        //    //}
        //}

        //private static void BrandWork()
        ////{
        ////    BrandManager brandManager = new BrandManager(new EfBrandDal(),new FileLogger());
        ////    brandManager.Add(new Brand() {BrandName = "Fiat"});
        ////    brandManager.Add(new Brand() {BrandName = "Fiat - 2"});
        ////    var brandalldata = brandManager.GetAll();
        //    //foreach (var brand in brandalldata)
        //    //{
        //    //    Console.WriteLine(brand.BrandName + " --- " + brand.Id);
        //    //}

        //    //brandManager.Delete(new Brand{BrandName = "Fiat",Id = 2});
        //    //var brandalldata2 = brandManager.GetAll();
        //    //foreach (var brand in brandalldata2)
        //    //{
        //    //    Console.WriteLine(brand.BrandName + " --- " + brand.Id);
        //    //}

        //    //brandManager.Delete(brandalldata.SingleOrDefault(p => p.Id == 2));
        //}

        //private static void NewMethod()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal(),new FileLogger());
        //    brandManager.Add(
        //        new Brand()
        //        {
        //            BrandName = "Ford"
        //        });
        //    var databrand = brandManager.GetAll();
        //    //foreach (var data in databrand)
        //    //{
        //    //    Console.WriteLine(data.BrandName);
        //    //}

        //    var databrandsize = brandManager.GetByLetterSize(p => p.BrandName.Length > 3);
        //    //foreach (var data in databrandsize)
        //    //{
        //    //    Console.WriteLine(data.BrandName);
        //    //}
        //}

        //private static void CarList(CarManager carManager)
        //{
        //    var carsbybrand = carManager.GetCarsByBrandId(1);
        //    foreach (var car in carsbybrand.Data)
        //    {
        //        Console.WriteLine(car.CarName);
        //    }

        //    var carsbycolor = carManager.GetCarsByColorId(2);
        //    //foreach (var car in carsbycolor.Data)
        //    //{
        //    //    Console.WriteLine(car.CarName);
        //    //}
        //}

        //private static CarManager ListCar()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    var item = carManager.GetAll();
        //    foreach (var car in item.Data)
        //    {
        //        Console.WriteLine(car.Description);
        //    }

        //    return carManager;
        //}

        //private static void ColorAdd()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    colorManager.Add(new Color()
        //    {
        //        ColorName = "Purple",
        //    });
        //}
    }
}
