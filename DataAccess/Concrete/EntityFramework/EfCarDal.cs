using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCarContext>, ICarDal
    {




        public List<CarDetailsDto> GetCarDetail()
        {
            using (ReCarContext context = new ReCarContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.BrandId
                        join cars in context.Cars
                            on c.CarName equals cars.CarName
                    join co in context.Colors
                        on c.ColorId equals co.ColorId
                    select new CarDetailsDto
                    {
                        CarId = c.CarId,
                        CarName = cars.CarName,
                        BrandName = b.BrandName,
                        DailyPrice = c.DailyPrice,
                        ColorName = co.ColorName
                    };

                return result.ToList();
            }
        }
    }
}
