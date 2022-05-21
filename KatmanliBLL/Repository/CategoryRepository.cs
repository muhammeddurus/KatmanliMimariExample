using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KatmanliDAL;
using KatmanliDTO;

namespace KatmanliBLL.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        NorthwindEntities db = ConnectionSettings.DbInstance;
        public void Delete(int itemId)
        {
            Category deleted = db.Categories.Find(itemId);
            db.Categories.Remove(deleted);
            db.SaveChanges();
        }

        public List<CategoryDto> GetAll()
        {
            try
            {
                List<CategoryDto> categoryDtos = new List<CategoryDto>();
                List<Category> categories = db.Categories.ToList();
                foreach (var item in categories)
                {
                    var donenDto = CategoryToCategoryDto(item);
                    categoryDtos.Add(donenDto);
                }

                return categoryDtos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }


        }

        public CategoryDto GetById(int itemId)
        {
            var category = db.Categories.Find(itemId);
            return CategoryToCategoryDto(category);
        }

        public void Insert(Category item)
        {
            db.Categories.Add(item);
            db.SaveChanges();
        }

        public void Update(Category item)
        {
            db.Entry(db.Customers.Find(item.CategoryID)).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
        private CategoryDto CategoryToCategoryDto(Category category)
        {
            return new CategoryDto
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName,
                Description = category.Description

            };
        }
    }
}
