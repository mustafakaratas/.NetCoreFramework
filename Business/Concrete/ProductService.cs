﻿using Business.Abstract;
using Business.Common.Constants;
using Core.Utilities.Result;
using Data.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IDataResult<Product> GetById(int productId)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productRepository.GetAll().ToList());
        }

        public IDataResult<List<Product>> GetListByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productRepository.GetAll(x => x.CategoryId == categoryId).ToList());
        }

        public IDataResult<Product> Add(Product product)
        {
            return new SuccessDataResult<Product>(_productRepository.Add(product));
        }

        public IResult Delete(Product product)
        {
            _productRepository.Delete(product);
            return new SuccessResult(string.Format(Messages.ProductDeleted, product.ProductId));
        }

        public IDataResult<Product> Update(Product product)
        {
            return new SuccessDataResult<Product>(_productRepository.Update(product));
        }
    }
}