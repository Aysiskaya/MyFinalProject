using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Coree.Aspects.Autofac.Validation;
using Coree.CrossCuttingConserns.Validation;
using Coree.Utilities.Business;
using Coree.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
       
       

        public ProductManager(IProductDal productDal, ICategoryService categoryService )
        {
            _productDal = productDal;
            _categoryService = categoryService;
           
          
        }

        //Claim 
       //[SecuredOperation("product.add, admin")]
        [ValidationAspect(typeof(ProductValidator))] // Add metodunu doğrula productvalidatordaki kurallara göre
        public IResult Add(Product product)
        {
            //business codes
           IResult result= BusinessRules.Run(CheckIfProductCoountOfCategoryCorret(product.CategoryId), 
                CheckIfProductNameExists(product.ProductName), CheckIfCategoryLimitEcceded());
            if (result!=null)
            {
                return result;  
            }
            _productDal.Add(product);

            return new SucccessResult(Messages.ProductAdded);

            
        } 
           
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==id));
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return  new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId== productId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result > 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            throw new NotImplementedException();
        }
        private IResult CheckIfProductCoountOfCategoryCorret(int CategoryId)
        {
            // select count(*) from products where categoryıd=1
            var result = _productDal.GetAll(p => p.CategoryId == CategoryId).Count;
            if (result > 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SucccessResult();
        }
        private IResult CheckIfProductNameExists (string ProductName)
        {
            
            var result = _productDal.GetAll(p => p.ProductName == ProductName).Any();
            if (result == true)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SucccessResult();
        }
        private IResult CheckIfCategoryLimitEcceded ()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SucccessResult();
        }

    }
   


}
