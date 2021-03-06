﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
   public interface ICarService
   {
       IDataResult<List<Car>> GetAll();
       IDataResult<List<Car>> GetCarsByBrandId(int id);
       IDataResult<List<Car>> GetCarsByColorId(int id);
       IDataResult<List<CarDetailsDto>> GetCarDetails();
      
       IResult Add(Car car);
       IResult Update(Car car);
       IResult Delete(Car car);
    }
}
