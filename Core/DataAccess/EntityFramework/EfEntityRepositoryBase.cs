﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;


using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
   public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
                            where TEntity:class,IEntity,new ()
                            where TContext:DbContext,new ()
                    
    {
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Add(TEntity entity)
        {
            //Idisposable patteren implementation of c#
            //using bittiği anda bellegı temizleme

            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);//referansı yakala
                addedEntity.State = EntityState.Added; // eklenecek nesne
                context.SaveChanges();
            }

        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var uptadedEntity = context.Entry(entity);//referansı yakala
                uptadedEntity.State = EntityState.Modified; // eklenecek nesne
                context.SaveChanges();// ekle kaydet anlamında
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);//referansı yakala
                deletedEntity.State = EntityState.Deleted; // eklenecek nesne
                context.SaveChanges();// ekle kaydet anlamında
            }
        }
    }
}
