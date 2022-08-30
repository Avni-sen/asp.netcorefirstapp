using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductUpdated = "Ürün Başarıyla Güncellendi.";
        public static string ProductDeleted = "Ürün Başarıyla Silindi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz!";
        public static string MaintenanceTime = "Şuan Sistem Bakımda.";
        public static string ProductListed = "Ürünler Listelendi.";
        public static string ProductListedById = "Ürün Id ye Göre Listelendi.";
        public static string ProductListedByCategoryId = "Category Id ye Göre Listelendi.";
        public static string ProductListedByUnitPrice = "UnitPrice'a Göre Listelendi.";
        public static string ProductDetailsDtos = "Ürün Detayları Yazdırıldı.";
        public static string ProductCountOfCategoryError = "Bir Kategoriye bu kadar ürün tek sefer kaydedilemez.Max 10 ürün eklenebilir.";
        public static string ProductNameAlreadySave = "Bu isimde bir ürün daha önce kaydedilmiş";
        public static string CategoryCounteExceeded = "Kategori sayısı sınırı aştı ürün kaydı yapılamaz.";
        public static string CategoryListedById = "Kategori id ye göre Listelendi.";
        public static string CategoriesListed = "Kategoriler Listelendi.";
        public static string CustomerListed = "Müşteriler Listelendi.";
        public static string CustomerListedById = "Müşteri id ye göre Listelendi.";
        public static string CustomerListedByCity = "Müşteri şehir adına göre Listelendi.";
    }
}
