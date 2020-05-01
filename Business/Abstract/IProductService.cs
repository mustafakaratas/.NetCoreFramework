using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetList();
        List<Product> GetListByCategory(int categoryId);
        Product Add(Product product);
        Product Delete(Product product);
        Product Update(Product product);
    }
}
