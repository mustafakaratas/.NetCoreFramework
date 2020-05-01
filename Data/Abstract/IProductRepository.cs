using Core.Data.Abstract;
using Entities.Concrete;

namespace Data.Abstract
{
    public interface IProductRepository : IEntityRepository<Product>
    {
    }
}
