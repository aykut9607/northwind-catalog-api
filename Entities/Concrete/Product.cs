using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Product : IEntity
    //public olmasının sebebi diğer katmanlardan erişebilmek için. Eğer internal olursa sadece Entities katmanından erişilebilir.
    // referans olarak core u verdik.
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }= string.Empty;
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
