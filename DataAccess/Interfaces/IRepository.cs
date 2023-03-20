using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IRepository<IEntity> where IEntity : class
    {
        // CRUD opetations
        IEnumerable<IEntity> Get(
            Expression<Func<IEntity, bool>>? filter = null,
            Func<IQueryable<IEntity>, IOrderedQueryable<IEntity>>? orderBy = null,
            string includeProperties = "");

        IEntity GetByID(object id);
        void Insert(IEntity entity);
        void Delete(object id);
        void Delete(IEntity entityToDelete);
        void Update(IEntity entityToUpdate);

        void Save();
    }
}
