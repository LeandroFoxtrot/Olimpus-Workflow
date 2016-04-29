using System;
using System.Linq;
using System.Linq.Expressions;
using Lead7.Olimpus.Domain;

namespace Lead7.Olimpus.Repository
{
    public interface IRepository { }

    public interface IRepository<TEntity, in TPrimaryKey> : IRepository where TEntity : Entity<TPrimaryKey>
    {
        void Create(TEntity entity);
        TEntity Get(TPrimaryKey id);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity entity);
        void Delete(TPrimaryKey id);
        void Delete(Expression<Func<TEntity, bool>> predicate);        
    }
}