namespace SalesAndService.Core.Utilities.Pagination.ComplexTypes
{
    public abstract class RequestParameters // arama yapacağımız her nesne için tek tek search objesi oluşturulmalı ve buradan kalıtım alınmalıdır. bu kalıp tüm arama nesneleri (pager için ortak property leri içermektedir)
    {
        const int MaxPageSize = 50; // kaç adet kart gözükecek maksimum ? 
        public int PageNumber { get { return (_pageNumber == 0 ? 1 : _pageNumber); } set { _pageNumber = value; } } // anlık sayfa bilgisi 
        public int _pageNumber { get; set; }


        private int _pageSize;
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                if (MaxPageSize < value)
                {
                    _pageSize = MaxPageSize;
                }
                else
                {
                    _pageSize = value;
                }

            }

        }
    }
}

