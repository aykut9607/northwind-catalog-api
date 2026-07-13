using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProductDal efProductDal = new EfProductDal();
            ICategoryDal efcategoryDal = new EfCategoryDal();

            IProductService productManager = new ProductManager(efProductDal, efcategoryDal);
            var result = productManager.GetProductDetails();

            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(
                         $"Product Name: {product.ProductName}, " +
                         $"Category: {product.CategoryName}, " +
                         $"Stock: {product.UnitsInStock}"
);
                }
            }

            else {
                Console.WriteLine(result.Message);
            }

            
        }


    }
}
