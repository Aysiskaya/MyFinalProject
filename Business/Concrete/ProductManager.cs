﻿using Business.Abstract;
using Coree.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult  Add(Product product)
        {
            //business codes 

            if (product.ProductName.Length < 2)
            {
                return new ErrorResult("Üürün ismi min 2 karakter olmalıdır.");
            }
            _productDal.Add(product);
            return new SucccessResult ("Ürün eklendi");
        }

        public List<Product> GetAll()
        {
            //İş kodları
            ////Yetkisi var mı? vs vs 

            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetAllByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p=>p.ProductId== productId);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}