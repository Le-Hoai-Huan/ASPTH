using WebBanHang.Models;

namespace WebBanHang.Repository
{
    public interface IProductReponsitory
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
