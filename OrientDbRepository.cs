using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevStack.Pattern;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using RevStack.OrientDb.Client;

namespace RevStack.OrientDb
{
    public class OrientDbRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly OrientDbDatabase _database;
        private readonly HttpQueryProvider _queryProvider;

        public OrientDbRepository(IDataContext context)
        {
            var orientDbContext = (OrientDbContext)context;
            _database = orientDbContext.Database;
            _queryProvider = new HttpQueryProvider(orientDbContext.Connection);
        }

        public IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = new Query.Query<TEntity>(_queryProvider);
            return query.ToList().AsEnumerable<TEntity>();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return new Query.Query<TEntity>(_queryProvider).Where(predicate);
        }

        public TEntity Add(TEntity entity)
        {
            return _database.Insert<TEntity>(entity);
        }

        public TEntity Update(TEntity entity)
        {
            return _database.Update<TEntity>(entity);
        }

        public void Delete(TEntity entity)
        {
            _database.Delete<TEntity>(entity);
        }
        
        public void Execute(string command)
        {
            _database.Execute(command);
        }

        public void Batch(IList<TEntity> entity)
        {
            _database.Batch(entity);
        }
    }
}
