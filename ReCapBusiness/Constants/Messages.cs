using ReCapProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ReCapProjectBusiness.Constants
{
    public static class Messages
    {
        //Ekleme
        public static string AddedMessage = " Ekleme İşlemi Başarılı!";
        public static string AddedErrorMessage = " Ekleme İşlemi Gerçekleşemedi! Lütfen İlgili Alanları Kontrol Ediniz!";
        //Silme
        public static string DeletedMessage = "Silme İşlemi Başarılı!";
        public static string DeletedErrorMessage = "Ekleme İşlemi Gerçekleşemedi! Lütfen Sistem Yöneticinizle İletişime Geçiniz!";
        //Güncelleme
        public static string UpdatedMessage = "Güncelleme İşlemi Başarılı!";
        public static string UpdatedErrorMessage = " Güncelleme İşlemi Gerçekleşemedi! Lütfen Sistem Yöneticinizle İletişime Geçiniz!";
        //Listeleme
        public static string ListedMessage = "Listeleme Başarılı!";
        public static string ListedErrorMessage = "Listeleme Yapılırken Bir Sorun Oluştur!";
        //Kiralama
        public static string Rental = "Araç Kiralandı!";
        public static string RentalError = "Araç bir başka müşteride!";

        //İsim hata mesajı
        public static string NameError = "Aynı isimden sadece bir kez kayıt yapılabilir!";

        //Resim işlemleri
        public static string ImageNoLimit = "Bir arabanın sadece 5 adet resmi olabilir!";
        public static string ImagesAdded = "Görsel yükleme işlemi başarılı!";
        public static string UnsupportedFile = "Desteklenmeyen dosya türü!";
        public static string AddedImage = "Görsel ekleme işlemi başarılı!";
        public static string ErrorImage = "Eklenecek bir resim bulunamadı!";
        public static string ImageNotFound = "Bir dosya gönderilmedi!";
        public static string ImageDeleted = "Görsel silindi!";

        //Login işlemleri
        public static string UserRegistired = "Kullanıcı başarıyla oluşturuldu!";
        public static string UserAlreadyExists = "Böyle bir kullanıcı zaten mevcut!";
        public static string AccessTokenCreated = "Token oluşturuldu!";
        public static string UserNotFound = "Böyle bir kullanıcı bulunamadı!";
        public static string PasswordError = "Kullanıcı adı veya parola hatalı!";
        public static string SuccessfulLogin = "Başarılı bir şekilde giriş yapıldı!";
        public static string AuthorizationDenied = "Yetkiniz bulunmamakta!";
    }
}
