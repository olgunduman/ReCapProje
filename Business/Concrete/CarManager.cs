using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class CarManager:ICarService

    { ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            //burada iş kodları yazılır

            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0 && car.Description.Length>2)
            {
                _carDal.Add(car);
                Console.WriteLine("Araç sisteme kayıt edilmiştir.");

            }
            else
            {
                Console.WriteLine("Araç günlük fiyatı 0 dan büyük ve araç ismi 2 karakterden fazla olmalıdır.");
            }
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }
    }
}
