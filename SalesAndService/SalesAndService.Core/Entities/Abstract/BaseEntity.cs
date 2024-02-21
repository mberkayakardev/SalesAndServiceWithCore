
namespace SalesAndService.Core.Entities.Abstract
{
    public class BaseEntity : IEntity
    {
        // başlangıç değerleri burada atanabilir. ilgili yapılandırma yapılabilir. 
        public int Id { get ; set ; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get ; set ; } = DateTime.Now; // nesne ilk oluşturulurken o anki tarih verilecektir. 
        public string CreatedUserName { get ; set ; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public string ModifiedUserName { get ; set ; }
    }
}
