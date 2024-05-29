using CabBookingPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace CabBookingPortal.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal CabBookingPortalContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(CabBookingPortalContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return dbSet.ToList();
        }

        public virtual TEntity? GetByID(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(int id)
        {
            TEntity? entityToDelete = dbSet.Find(id);
            if (entityToDelete is not null) Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

    }
}
