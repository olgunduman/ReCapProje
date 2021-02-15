﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
   public interface IRentalService

   {
       IDataResult<List<Rental>> GetAll();
       IDataResult<List<RentalDetailsDto>> GetRentalDetails();
       IResult Add(Rental rental);
       IResult Delete(Rental rental);
       IResult Update(Rental rental);
    }
}
