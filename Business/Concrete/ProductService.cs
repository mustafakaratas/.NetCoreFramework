using Business.Abstract;
using Data.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public Product Delete(Product product)
        {
            return _productRepository.Delete(product);
        }

        public List<Product> GetList()
        {
            return _productRepository.GetAll().ToList();
        }

        public List<Product> GetListByCategory(int categoryId)
        {
            return _productRepository.GetAll(x => x.CategoryId == categoryId).ToList();
        }

        public Product Update(Product product)
        {
            return _productRepository.Update(product);
        }
    }
}
