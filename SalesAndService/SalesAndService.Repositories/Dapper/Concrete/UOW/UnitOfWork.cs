using Dapper;
using SalesAndService.Core.DataAccess.Dapper.Abstract;
using SalesAndService.Core.DataAccess.Dapper.Concrete;
using SalesAndService.Repositories.Dapper.Abstract;
using System.Data;

namespace SalesAndService.Repositories.Dapper.Concrete.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Tanimlar
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;
        #endregion

        public UnitOfWork(IDbConnection dbConnection)
        {
            _connection = dbConnection;
            _connection.Open();
        }

        #region Transaction İşlemleri
        public void BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
        }
        public void Commit()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
                _transaction.Dispose();
                _transaction = null;
            }
        }
        public void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
                _transaction = null;
            }
        }
        #endregion

        #region Query/Execute Operation
        public int ExecuteQuery(string Query)
        {
            var result = _connection.Execute(Query, _transaction);
            return result;
        }
        public IEnumerable<T> GetData<T>(string Query)
        {
            return _connection.Query<T>(Query);
        }
        #endregion

        IDpGenericRepository<TEntity> IUnitOfWork.GetGenericRepository<TEntity>()
        {
            return new DpGenericRepository<TEntity>(_connection, _transaction);
        }


        //public TRepository GetRepository<T, TRepository>() where T : IEntity where TRepository : IGenericRepository<T>
        //{
        //    return (TRepository)Activator.CreateInstance(typeof(T), _connection, _transaction);
        //}
    }
}
