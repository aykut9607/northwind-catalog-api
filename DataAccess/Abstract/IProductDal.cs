using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        //burda Product a kızacak bana referans ver dicek.orda ampule tıklayıp referansı eklicez.
        //referansı eklemezsek yukarıdaki using Entities.Concrete; kodunun bir onemi kalmıyor
        //referance vermek demek dataaccess katmanının  entities katmanına bağımlı olduğunu gösteriyor.
        //eger o calısmazsa dataaccess sağ tıkla > add > reference > project > entities seç
        //(bir tane secmen gerekiyor her seferinde.gidip birden fazla seceyim hepsini seceyim mantıklı değil gereksiz baglılık yaratmıs oluyoruz.)
        //Core a da referance verdik .


        List<ProductDetailDto> GetProductDetails();
    }
}
