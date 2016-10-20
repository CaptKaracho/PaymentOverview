using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace PO.Data.Repository
{
    public class RepositoryGeneric : Repository
    {
        public RepositoryGeneric() : base()
        {
        }
        public RepositoryGeneric(string Username) : base(Username)
        { }

        public List<TEntity> GetAll<TEntity>()
            where TEntity : class, new()
        {
            return this.Context.Set<TEntity>().ToList();
        }

        public List<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> WhereClause)
            where TEntity : class, new()
        {
            return this.Context.Set<TEntity>().Where(WhereClause).ToList();
        }

        public TEntity Add<TEntity>(TEntity Data, bool InstantSave) where TEntity : class, new()
        {
            this.Context.Set<TEntity>().Add(Data);

            this.SetChangeProperties<TEntity>(Data);

            if (InstantSave)
                this.Context.SaveChanges();

            return Data;
        }

    }
}
