using Project.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Service
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        //Create
        void CreateCategory(Category category);
        //Delete
        void RemoveCategory(Category category);
        //Update
        void UpdateCategory(Category category);
        //Get
        Category Get(int id);


    }
}
