using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCarDal:ICarDal
    {
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCarContext context = new ReCarContext())
            {
                return filter == null 
                    ? context.Set<Car>().ToList() 
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCarContext context = new ReCarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public void Add(Car entity)
        {
            //Idisposable patteren implementation of c#
            //using bittiği anda bellegı temizleme

            using (ReCarContext context = new ReCarContext())
            {
                var addedEntity = context.Entry(entity);//referansı yakala
                addedEntity.State = EntityState.Added; // eklenecek nesne
                context.SaveChanges();// ekle kaydet anlamında
            }

        }

        public void Update(Car entity)
        {
            using (ReCarContext context = new ReCarContext())
            {
                var uptadedEntity = context.Entry(entity);//referansı yakala
                uptadedEntity.State = EntityState.Modified; // eklenecek nesne
                context.SaveChanges();// ekle kaydet anlamında
            }
        }

        public void Delete(Car entity)
        {
            using (ReCarContext context = new ReCarContext())
            {
                var deletedEntity = context.Entry(entity);//referansı yakala
                deletedEntity.State = EntityState.Deleted; // eklenecek nesne
                context.SaveChanges();// ekle kaydet anlamında
            }
        }
    }
}
