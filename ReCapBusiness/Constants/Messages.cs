using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.Constants
{
    public static class Messages
    {
        public static string AddedMessage = " Ekleme İşlemi Başarılı!";
        public static string AddedErrorMessage = " Ekleme İşlemi Gerçekleşemedi! Lütfen İlgili Alanları Kontrol Ediniz!";

        public static string DeletedMessage = "Silme İşlemi Başarılı!";
        public static string DeletedErrorMessage = "Ekleme İşlemi Gerçekleşemedi! Lütfen Sistem Yöneticinizle İletişime Geçiniz!";

        public static string UpdatedMessage = "Güncelleme İşlemi Başarılı!";
        public static string UpdatedErrorMessage = " Güncelleme İşlemi Gerçekleşemedi! Lütfen Sistem Yöneticinizle İletişime Geçiniz!";

        public static string ListedMessage = "Listeleme Başarılı!";
        public static string ListedErrorMessage = "Listeleme Yapılırken Bir Sorun Oluştur!";

        public static string Rental = "Araç Kiralandı!";
        public static string RentalError = "Araç bir başka müşteride!";


        public static string ColorNameError = "Aynı isimden sadece bir kez kayıt yapılabilir!";

        public static string ImageNoLimit = "Bir arabanın sadece 5 adet resmi olabilir!";
        public static string ImagesAdded = "Görsel yükleme işlemi başarılı!";
        public static string UnsupportedFile = "Desteklenmeyen dosya türü!";
        public static string AddedImage = "Görsel ekleme işlemi başarılı!";
        public static string ErrorImage = "Eklenecek bir resim bulunamadı!";
        public static string ImageNotFound = "Bir dosya gönderilmedi!";
        public static string ImageDeleted = "Görsel silindi!";
    }
}
