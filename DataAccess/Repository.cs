using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Repository<IEntity> : IRepository<IEntity> where IEntity : class
    {

        internal CarDbContext context;
        internal DbSet<IEntity> dbSet;

        public Repository(CarDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<IEntity>();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public virtual IEnumerable<IEntity> Get(
            Expression<Func<IEntity, bool>>? filter = null,
            Func<IQueryable<IEntity>, IOrderedQueryable<IEntity>>? orderBy = null,
            string includeProperties = "")
        { 
            IQueryable<IEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual IEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(IEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            IEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(IEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(IEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
