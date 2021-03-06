﻿using Core.Data.Concrete;
using Data.Abstract;
using Data.Concrete.Contexts;
using Entities.Concrete;

namespace Data.Concrete
{
    public class ProductRepository : EntityRepositoryBase<Product, NorthwindContext>, IProductRepository
    {

    }
}
