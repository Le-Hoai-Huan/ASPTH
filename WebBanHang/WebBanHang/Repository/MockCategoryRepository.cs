using WebBanHang.Models;

namespace WebBanHang.Repository
{
    public class MockCategoryRepository : ICategoryRepository
    {
        private readonly List<Category> _categories;
        public MockCategoryRepository()
        {
            _categories = new List<Category>
            {
                new Category { Id = 1, Name = "Smartphone" },
                new Category { Id = 2, Name = "Tablet" },
                new Category { Id = 3, Name = "Laptop" },
            };
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _categories;
        }
        public Category GetById(int id)
        {
            return _categories.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Category category)
        {
            category.Id = _categories.Max(p => p.Id) + 1;
            _categories.Add(category);
        }
        public void Update(Category category)
        {
            var index = _categories.FindIndex(p => p.Id == category.Id);
            if (index != -1)
            {
                _categories[index] = category;
            }
        }
        public void Delete(int id)
        {
            var category = _categories.FirstOrDefault(p => p.Id == id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}
