using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Common.Constants;
using Business.Validation.FluentValidation;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Logging;
using Core.Aspects.AutoFac.Performance;
using Core.Aspects.AutoFac.Transaction;
using Core.Aspects.AutoFac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Result;
using Data.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
            return new SuccessDataResult<Product>(_productRepository.Get(x => x.ProductId == productId));
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productRepository.GetAll().ToList());
        }

        //[CacheAspect(duration: 1440)]
        //[SecuredOperation("LoginUser")]
        //[PerformanceAspect(interval: 5)]
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<List<Product>> GetListByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productRepository.GetAll(x => x.CategoryId == categoryId).ToList());
        }

        [ValidationAspect(typeof(AddProductValidator), Priority = 1)]
        [CacheRemoveAspect(pattern: "IProductService.Get")]
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

        [TransactionScopeAspect]
        public IResult TransactionTest(Product product)
        {
            _productRepository.Update(product);
            _productRepository.Add(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
