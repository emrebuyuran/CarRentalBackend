using System;
using System.Dynamic;
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
            //GetAllTest();

            //ColorTest();

            //BrandTest();
            
            //CarDetailDtoTest();

            //DeleteTest();

            //UserListTest();

            //AddRentalTest();
        }

        private static void AddRentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental {CarId = 1, CustomerId = 1, RentDate = DateTime.Now });
            var result = rentalManager.GetAll();
            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.CarId + " " + rental.CustomerId + " " + rental.RentDate);
                }
                Console.WriteLine(result.Message);
            }
        }

        private static void UserListTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            if (result.Success==true)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.FirstName+" "+user.LastName);
                }
                Console.WriteLine(result.Message);
            }
        }

        //private static void DeleteTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    carManager.Delete(new Car {Id = 4});
        //}

        //private static void CarDetailDtoTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    var result = carManager.GetCarDetails();
        //    if (result.Success == true)
        //    {
        //        foreach (var carDetail in result.Data)
        //        {
        //            Console.WriteLine(carDetail.BrandName + " " + carDetail.CarName + " " + carDetail.ColorName + " " +
        //                              carDetail.DailyPrice);
        //        }
        //        Console.WriteLine(result.Message);
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
            
        //}

        //private static void BrandTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    brandManager.Update(new Brand {Id = 3, Name = "Skoda"});
        //    GetAllTest();
          
            
        //}

        //private static void ColorTest()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    colorManager.Update(new Color
        //    {
        //        Id = 1, Name = "Beyaz"
        //    });
        //    GetAllTest();
        //}

        //private static void GetAllTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    var result = carManager.GetAll();
        //    if (result.Success==true)
        //    {
        //        foreach (var car in result.Data)
        //        {
        //            Console.WriteLine(car.Id + " " + car.BrandId + " " + car.ColorId + " " + car.DailyPrice + " " + car.ModelYear +
        //                              " " + car.Description);
        //        }
        //        Console.WriteLine(result.Message);
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
            
        //}
    }
}
