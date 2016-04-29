using System;
using NHibernate;

namespace Lead7.Olimpus.Dependency.UnitOfWork
{
    public class NHUnitOfWork : IUnitOfWork
    {
        public static NHUnitOfWork Current
        {
            get { return _current; }
            set { _current = value; }
        }

        [ThreadStatic]
        private static NHUnitOfWork _current;

        public ISession Session { get; private set; }

        private readonly ISessionFactory _sessionFactory;

        private ITransaction _transaction;

        public NHUnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public void BeginTransaction()
        {
            Session = _sessionFactory.OpenSession();
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            finally
            {
                Session.Close();
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction.Rollback();
            }
            finally
            {
                Session.Close();
            }
        }
    }
}