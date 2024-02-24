using SalesAndService.Core.DataAccess.Dapper.Abstract;
using SalesAndService.Core.Entities.Abstract;

namespace SalesAndService.Repositories.Dapper.Abstract
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Transaction Başlatma
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Transaction işleme
        /// </summary>
        void Commit();


        /// <summary>
        /// Transaction Geri Alma
        /// </summary>
        void Rollback();


        /// <summary>
        /// Repository entity vastıası ile generic bir şekilde çağırma
        /// </summary>
        IDpGenericRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : class, IEntity, new();
        /// <summary>
        /// Costume Repository çağrımı yapma 
        /// </summary>
        /// 
        //TRepository GetRepository<T, TRepository>() where T : IEntity where TRepository : IDpGenericRepository<T>;

        /// <summary>
        /// Repository bağımsız select işlemi 
        /// </summary>
        public IEnumerable<T> GetData<T>(string Query);

        /// <summary>
        /// Repository bağımsız Tetikleme veya execute işlemleri 
        /// </summary>
        int ExecuteQuery(string Query);
    }
}
