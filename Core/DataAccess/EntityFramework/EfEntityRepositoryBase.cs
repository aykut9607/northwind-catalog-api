using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
       where TEntity : class, IEntity, new()
       where TContext : DbContext, new()

        //burda TEntity ve TContext generic tiplerdir. IEntityRepository deki T ile aynı şeydir. TEntity yerine Product, Category, Customer gibi entityler gelebilir.
        //TContext yerine ise DbContext den türeyen context sınıfları gelebilir.

        //solution a nuget paketlerinden Microsoft.EntityFrameworkCore.SqlServer ı ekledik:

    {

        public void Add(TEntity entity)
        {

            //IDisposable pattern implementation of c# using block
            //garbage collector:çöp toplayıcı.çöp toplayıcı bellek yönetimi yapar.
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);//referansı yakala
                addedEntity.State = EntityState.Added;//ekleme yap
                context.SaveChanges();
            }
        }


        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        
    }
}
