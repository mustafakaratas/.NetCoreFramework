using Business.Abstract;
using Core.Utilities.Result;
using Data.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryRepository.GetAll().ToList());
        }
    }
}
