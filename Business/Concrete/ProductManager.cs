
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;


namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryDal _categoryDal;

        public ProductManager(
            IProductDal productDal,
            ICategoryDal categoryDal)
        {
            _productDal = productDal;
            _categoryDal = categoryDal;
        }

        public IResult Add(Product product)
        {
            IResult validationResult = ValidateProduct(product);

            if (!validationResult.Success)
            {
                return validationResult;
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(Product product)
        {
            Product existingProduct = _productDal.Get(
                p => p.ProductId == product.ProductId
            );

            if (existingProduct == null)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }

            IResult validationResult = ValidateProduct(product);

            if (!validationResult.Success)
            {
                return validationResult;
            }

            _productDal.Update(product);

            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Delete(Product product)
        {
            Product productToDelete = _productDal.Get(
                p => p.ProductId == product.ProductId
            );

            if (productToDelete == null)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }

            _productDal.Delete(productToDelete);

            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(
                _productDal.GetAll(),
                Messages.ProductListed
            );
        }

        public IDataResult<Product> GetById(int productId)
        {
            Product product = _productDal.Get(
                p => p.ProductId == productId
            );

            if (product == null)
            {
                return new ErrorDataResult<Product>(
                    Messages.ProductNotFound
                );
            }

            return new SuccessDataResult<Product>(product);
        }

        public IDataResult<List<Product>> GetAllByCategory(
            int categoryId)
        {
            return new SuccessDataResult<List<Product>>(
                _productDal.GetAll(
                    p => p.CategoryId == categoryId
                )
            );
        }

        public IDataResult<List<Product>> GetByUnitPrice(
            decimal min,
            decimal max)
        {
            if (min > max)
            {
                return new ErrorDataResult<List<Product>>(
                    Messages.ProductPriceRangeInvalid
                );
            }

            return new SuccessDataResult<List<Product>>(
                _productDal.GetAll(
                    p => p.UnitPrice >= min &&
                         p.UnitPrice <= max
                )
            );
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(
                _productDal.GetProductDetails(),
                Messages.ProductDetailsListed
            );
        }

        private IResult ValidateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName) ||
                product.ProductName.Trim().Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            if (product.UnitPrice <= 0)
            {
                return new ErrorResult(Messages.ProductPriceInvalid);
            }

            if (product.UnitsInStock < 0)
            {
                return new ErrorResult(Messages.ProductStockInvalid);
            }

            Category category = _categoryDal.Get(
                c => c.CategoryId == product.CategoryId
            );

            if (category == null)
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }

            return new SuccessResult();
        }
    }
}
