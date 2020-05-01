using Core.Utilities.Result;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> GetById(int productId);
        IDataResult<List<Product>> GetList();
        IDataResult<List<Product>> GetListByCategoryId(int categoryId);
        IDataResult<Product> Add(Product product);
        IResult Delete(Product product);
        IDataResult<Product> Update(Product product);
    }
}
