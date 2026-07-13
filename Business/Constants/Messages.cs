using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    //static yaptık cunku sabit bir class olmasını istiyoruz. newlenmesini istemiyoruz.
    {
        public const string ProductAdded = "Ürün eklendi.";
        public const string ProductUpdated = "Ürün güncellendi.";
        public const string ProductDeleted = "Ürün silindi.";
        public const string ProductListed = "Ürünler listelendi.";
        public const string ProductDetailsListed ="Ürün detayları listelendi.";

        public const string ProductNotFound =
            "Ürün bulunamadı.";

        public const string ProductNameInvalid =
            "Ürün ismi en az iki karakter olmalı.";

        public const string ProductPriceInvalid =
            "Ürün fiyatı sıfırdan büyük olmalı.";

        public const string ProductStockInvalid =
            "Stok negatif olamaz.";

        public const string ProductPriceRangeInvalid =
            "Minimum fiyat maksimum fiyattan büyük olamaz.";

        public const string CategoryAdded = "Kategori eklendi.";
        public const string CategoryUpdated = "Kategori güncellendi.";
        public const string CategoryDeleted = "Kategori silindi.";
        public const string CategoryListed = "Kategoriler listelendi.";

        public const string CategoryNotFound =
            "Kategori bulunamadı.";

        public const string CategoryNameInvalid =
            "Kategori ismi en az iki karakter olmalı.";

        public const string CategoryHasProducts =
            "Bu kategoride ürün olduğu için kategori silinemez.";
    }
}
