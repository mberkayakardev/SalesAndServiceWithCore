﻿using SalesAndService.Core.Entities.Abstract;
using SalesAndService.Core.Utilities.Pagination.ComplexTypes;
using System.Linq.Expressions;

namespace SalesAndService.Core.DataAccess.EntityFramework.Abstract
{
    public interface IEfGenericRepository<T> where T: class, IEntity,new()
         
    {
        Task<T> CreateAsync(T Entity);  // Oluşturduğum Entitylerimi Dönmem gerekecektir. IEEE
        Task UpdateAsync(T Entity);
        Task DeleteAsync(T Entity);
        Task SoftDeleteAsync(T Entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where = null, bool AsNoTracking = true, params Expression<Func<T, object>>[] IncludeProperties); // ORder By Key ile birlikte yapılabilmesi açısından eklenmiş bir değerdir. 
        Task<List<T>> GetAllAsyncWithListExpression(IList<Expression<Func<T, bool>>> where = null, bool AsNoTracking = true, params Expression<Func<T, object>>[] IncludeProperties); // ORder By Key ile birlikte yapılabilmesi açısından eklenmiş bir değerdir. 
        Task<PagedList<T>> GetAllWithPagingAsync(RequestParameters parameters, Expression<Func<T, bool>> where = null, bool AsNoTracking = true, params Expression<Func<T, object>>[] IncludeProperties); // Paging ile veri gelmesini sağlar 
        Task<PagedList<T>> GetAllWithPagingAsync(RequestParameters parameters, IList<Expression<Func<T, bool>>> where = null, bool AsNoTracking = true, params Expression<Func<T, object>>[] IncludeProperties); // Paging ile veri gelmesini sağlar 
        Task<T> GetAsync(Expression<Func<T, bool>> where = null, bool AsNoTracking = false, params Expression<Func<T, object>>[] IncludeProperties); // Order By bu etapta sıralamaya göre ilk değerin alınması istenirse diye eklenmiştir.
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
        IQueryable<T> GetAsQueryable();
    }
}
