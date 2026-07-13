using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        IProductDal _productDal;

        public CategoryManager(
            ICategoryDal categoryDal,
            IProductDal productDal)
        {
            _categoryDal = categoryDal;
            _productDal = productDal;
        }

        public IResult Add(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName) ||
                category.CategoryName.Trim().Length < 2)
            {
                return new ErrorResult(Messages.CategoryNameInvalid);
            }

            _categoryDal.Add(category);

            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Update(Category category)
        {
            Category? existingCategory = _categoryDal.Get(
                c => c.CategoryId == category.CategoryId
            );

            if (existingCategory == null)
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }

            if (string.IsNullOrWhiteSpace(category.CategoryName) ||
                category.CategoryName.Trim().Length < 2)
            {
                return new ErrorResult(Messages.CategoryNameInvalid);
            }

            _categoryDal.Update(category);

            return new SuccessResult(Messages.CategoryUpdated);
        }

        public IResult Delete(int categoryId)
        {
            Category? category = _categoryDal.Get(
                c => c.CategoryId == categoryId
            );

            if (category == null)
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }

            List<Product> products = _productDal.GetAll(
                p => p.CategoryId == categoryId
            );

            if (products.Count > 0)
            {
                return new ErrorResult(Messages.CategoryHasProducts);
            }

            _categoryDal.Delete(category);

            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(
                _categoryDal.GetAll(),
                Messages.CategoryListed
            );
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            Category? category = _categoryDal.Get(
                c => c.CategoryId == categoryId
            );

            if (category == null)
            {
                return new ErrorDataResult<Category>(
                    Messages.CategoryNotFound
                );
            }

            return new SuccessDataResult<Category>(category);
        }
    }
}
