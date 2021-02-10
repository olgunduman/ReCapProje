using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Brandtest();
            CarJoinTest();
        }

        private static void CarJoinTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + car.DailyPrice);
            }
        }

        private static void Brandtest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }


        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
         
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
