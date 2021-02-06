using System;
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
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetByDailyPrice(50000,250000))
            {
                Console.Write(car.CarId + " : ");

                Console.WriteLine(car.Description + car.DailyPrice);
            }
        }
    }
}
