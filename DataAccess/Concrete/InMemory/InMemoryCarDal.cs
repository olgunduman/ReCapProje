using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
  public  class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car
                {
                    CarId =1, BrandId =1, ColorId =1, DailyPrice = 35000, ModelYear = 2018
                },
                new Car
                {
                    CarId =2, BrandId =1, ColorId =2, DailyPrice = 48000, ModelYear = 2016
                },
                new Car
                {
                    CarId =3, BrandId =2, ColorId =3, DailyPrice = 78000, ModelYear = 2021
                },
                new Car
                {
                    CarId =4, BrandId =2, ColorId =4, DailyPrice = 55000, ModelYear = 2019
                },
                new Car
                {
                    CarId =5, BrandId =3, ColorId =5, DailyPrice = 47500, ModelYear = 2015
                },
            };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int BrandId)
        {
            return _cars.Where(c => c.BrandId == BrandId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
           _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }
    }
}
