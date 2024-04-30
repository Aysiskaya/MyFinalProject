using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static  class Messages
    {
        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string  MaintenanceTime =  "Sistem bakımda";
        public static string ProductListed ="Ürünler Listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public  static string ProductNameAlreadyExists="Bu isimde zaten ürün var";
        internal static string CategoryLimitExceded="Kategori Limiti aşıldığı için tyeni ürün eklenemiyor.";
    }
}
