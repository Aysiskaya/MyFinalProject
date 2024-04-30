using Business.Abstract;
using Coree.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            //iş kodları
            return new SuccessDataResult<List<Category>>(_categorydal.GetAll());

        }

        // Select*From categories where CategoryId = 3 
        public IDataResult<Category> GetByCategoryId(int categoryId)
        {
            return new SuccessDataResult<Category> (_categorydal.Get(c=>c.CategoryId == categoryId));
        }
    }
}
