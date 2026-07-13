using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class ProductDetailDto : IDto
    //DTO: Data Transfer Object
    //şu anlama geliyor: veriyi bir yerden alıp başka bir yere taşımak için kullanılan nesne

    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public short UnitsInStock { get; set; }
    }
}
