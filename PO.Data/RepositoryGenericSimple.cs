using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PO.Data
{
    public class RepositoryGenericSimple<TEntity> : RepositoryBase where TEntity : class,new()
    {
        public RepositoryGenericSimple()
        {
        }

        public List<TEntity> GetAll()
        {
            return this.Set<TEntity>().ToList();
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> WhereClause)
        {
            return this.Set<TEntity>().Where(WhereClause).ToList();
        }

    }
}
