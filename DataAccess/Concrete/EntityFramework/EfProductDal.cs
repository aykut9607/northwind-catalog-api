using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthWindContext>, IProductDal
    {
        //EF:Object relational mapping(orm) destekli çalısır.microsoft ürünü.
        //linq destekli calısıyor.
        //orm:veritabanı nesneleriyle bağ kurup onları class gibi ilişkilendirir.

        //Nuget:Paketlerin ortak yonetildiği ortam.
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock
                             };
                return result.ToList();
            }    
        }
    }
}


