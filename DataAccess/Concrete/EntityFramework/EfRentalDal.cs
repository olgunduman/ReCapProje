using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCarContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (ReCarContext context = new ReCarContext())
            {
                var result = from r in context.Rentals
                    join c in context.Cars
                        on r.CarId equals c.CarId
                    join cstmr in context.Customers
                        on r.CustomerId equals cstmr.Id
                    join u in context.Users
                        on cstmr.UserId equals u.Id
                    select new RentalDetailsDto
                    {
                        RentId = r.Id,
                        CarName = c.CarName,
                        UserName = u.FirstName,
                        UserSurName = u.LastName,
                        CompanyName = cstmr.CompanyName,
                        RentDate = r.RentDate,
                        


                    };

                return result.ToList();

            }
            




        }
    }
}
