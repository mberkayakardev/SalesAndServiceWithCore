﻿namespace SalesAndService.Core.Utilities.Pagination.ComplexTypes
{
    public class PagedList<T> : List<T>
    {
        #region İnstance Member
        public MetaData MetaData { get; set; }
        public PagedList(List<T> items, int count, int pageNumber, int PageSize) // MEtaData için lazım
        {
            MetaData = new MetaData()
            {
                TotalCount = count, // Tüm Verilerin Count u 
                Pagesize = PageSize,
                CurrentPage = pageNumber,
                TotalPage = (int)Math.Ceiling(count / (double)PageSize)
            };
            AddRange(items); // gelen itemler eşleşti.
        }
        #endregion

        public static PagedList<T> ToPagedList(IEnumerable<T> Source, int PageNumber, int PageSize, int QueryCount)
        {
            return new PagedList<T>(Source.ToList(), QueryCount, PageNumber, PageSize);
        }
    }
}
