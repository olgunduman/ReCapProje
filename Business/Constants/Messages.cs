using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
   public class Messages
   {
       public static string ProductedAdded = "Araç Eklendi";
       public static string ProductNameInvalid = "Araç ismi geçersiz ";
       public static string MaintenanceTime = "Sistem bakımda";
       public static string ProductsListed="Araçlar Listelendi";
       public static string CarUptated="Araçlar güncellendi";
       public static string CarDeleted="Araçlar Silindi";
       public static string UsersList="Tüm Kullanıcılar Listelendi";
        internal static string CarImageIsNotExists;
        internal static string CarImageLimitExceeded;
    }
}
