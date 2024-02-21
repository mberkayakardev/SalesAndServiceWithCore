﻿using Dapper.Contrib.Extensions;
using SalesAndService.Core.DataAccess.Dapper.Abstract;
using SalesAndService.Core.Entities.Abstract;
using System.Data;

namespace SalesAndService.Core.DataAccess.Dapper.Concrete
{
    public class DpGenericRepository<T> : IDpGenericRepository<T> where T : class, IEntity, new()
    {
        protected readonly IDbConnection _Connection;
        protected readonly IDbTransaction _transaction;
        public DpGenericRepository(IDbConnection dbConnection, IDbTransaction transaction)
        {
            this._Connection = dbConnection;
            this._transaction = transaction;
        }

        public async Task AddAsync(T item)
        {
            await _Connection.InsertAsync<T>(item, _transaction);
        }

        public async Task DeleteAsync(T item)
        {
            await _Connection.DeleteAsync(item, _transaction);
        }

        public async Task<T> GetAsync(Func<T, bool> where = null)
        {
            var result = new T();
            result = await _Connection.GetAsync<T>(where);
            return result;

        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await GetAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetListAsync(Func<T, bool> where = null)
        {
            if (where == null)
            {
                var result = await _Connection.GetAllAsync<T>();
                return result;
            }

            var resultAll = await _Connection.GetAllAsync<T>();
            return resultAll.Where(where).ToList();


        }

        public async Task SoftDeleteAsync(T item)
        {
            item.IsActive = false;
            await _Connection.UpdateAsync(item, _transaction);
        }

        public async Task UpdateAsync(T item)
        {
            await _Connection.UpdateAsync(item, _transaction);

        }
    }
}
