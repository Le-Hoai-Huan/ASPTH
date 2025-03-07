using WebBanHang.Models;

namespace WebBanHang.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        Category GetById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
