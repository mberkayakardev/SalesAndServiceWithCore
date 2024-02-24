namespace SalesAndService.Core.Extentions.HttpContext
{
    public static class HttpContextExtentions
    {
        /// <summary>
        /// Cookie için parametre key değeri ile bir arama yapılır cookie de key varsa out tan cast edilmiş değişken alınır ve true değeri alınır. ilgili değer yoksa cookie de aynı şekilde null output ve false değeri alınır.
        /// </summary>
        /// <returns></returns>
        public static bool CookieTryGetValueWithCastingType<T>(this Microsoft.AspNetCore.Http.IHttpContextAccessor accessor, string key, out T value)
        {
            var CookieString = string.Empty;
            var returnresult = false;

            returnresult = accessor.HttpContext.Request.Cookies.TryGetValue(key, out CookieString);
            if (CookieString != string.Empty)
            {
                value = System.Text.Json.JsonSerializer.Deserialize<T>(CookieString);
                return true;
            }
            else
            {
                value = default;
                return false;
            }

        }

        /// <summary>
        /// Session için parametre key değeri ile bir arama yapılır cookie de key varsa out tan cast edilmiş değişken alınır ve true değeri alınır. 
        /// ilgili değer yoksa Session de aynı şekilde null output ve false değeri alınır.
        /// </summary>
        /// <returns></returns>
        public static bool SessionTryGetValueWithCastingType<T>(this Microsoft.AspNetCore.Http.IHttpContextAccessor accessor, string key, out T value)
        {
            var CookieString = string.Empty;
            var returnresult = false;

            returnresult = accessor.HttpContext.Request.Cookies.TryGetValue(key, out CookieString);
            if (CookieString != string.Empty)
            {
                value = System.Text.Json.JsonSerializer.Deserialize<T>(CookieString);
                return true;
            }
            else
            {
                value = default;
                return false;
            }


        }
    }
}
