namespace SalesAndService.Core.Entities.Abstract
{
    public interface IEntity // Gerek Reflectionlar ile gerekse kurallar için sistemde bulunacak sınıfları filtrelemek ve tek çatı altında toplayıp bunların bir Entity olduğunu belirtmek maksatlı konmuştur
    {
        public int Id { get; set; } // Tüm entitylerimde Id bilgisi olmak zorundadır. 
        public bool IsActive { get; set; } // ilgili alan true ise aktif değil ise Safedelete işlemi görmüş manasına gelir. 
        public DateTime CreatedDate { get; set; } // ilgili alan nesnelerin oluşturma tarihlerini belirtecektir.
        public string CreatedUserName { get; set; }
        public DateTime ModifiedDate { get; set; } // ilgili alan Son güncelleme tarihini belirtecek
        public string ModifiedUserName { get; set;} 


    }
}
