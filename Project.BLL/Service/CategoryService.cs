using Project.BLL.Repository;
using Project.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public void CreateCategory(Category category)
        {
            categoryRepository.Insert(category);
        }

        public Category Get(int id)
        {
            return categoryRepository.Get(id);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return categoryRepository.GetAll().ToList();
        }

        public void RemoveCategory(Category category)
        {
            categoryRepository.Remove(category);
        }

        public void UpdateCategory(Category category)
        {
            categoryRepository.Update(category);
        }
    }
}
