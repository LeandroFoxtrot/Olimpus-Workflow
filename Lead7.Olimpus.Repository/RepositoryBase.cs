using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Lead7.Olimpus.Domain;
using NHibernate;

namespace Lead7.Olimpus.Repository
{
    public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        protected ISession Session;

        protected RepositoryBase(ISession session)
        {
            Session = session;
        }

        public TEntity Get(TPrimaryKey id)
        {
            return Session.Get<TEntity>(id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            var obj = default(TEntity);
            var criteria = Session.CreateCriteria(typeof(TEntity));
            criteria.Add(NHibernate.Criterion.Restrictions.Where<TEntity>(predicate));
            obj = criteria.UniqueResult<TEntity>();
            return obj;
        }

        public IQueryable<TEntity> GetAll()
        {
            IList<TEntity> l = null;
            var criteria = Session.CreateCriteria(typeof(TEntity));
            l = criteria.List<TEntity>();
            return l.AsQueryable<TEntity>();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            IList<TEntity> l = null;
            var criteria = Session.CreateCriteria(typeof(TEntity));
            criteria.Add(NHibernate.Criterion.Restrictions.Where<TEntity>(predicate)).SetTimeout(180);
            l = criteria.List<TEntity>();
            return l.AsQueryable<TEntity>();
        }

        public void Create(TEntity entity)
        {
            Session.Save(entity);
            Session.Flush();
        }

        public void Update(TEntity entity)
        {
            Session.Update(entity);
            Session.Flush();
        }

        public void Delete(TPrimaryKey id)
        {
            Session.Delete(Session.Load<TEntity>(id));
            Session.Flush();
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var obj = default(TEntity);
            var criteria = Session.CreateCriteria(typeof(TEntity));
            criteria.Add(NHibernate.Criterion.Restrictions.Where<TEntity>(predicate));
            obj = criteria.UniqueResult<TEntity>();
            Session.Delete(obj);
            Session.Flush();
        }
    }

}