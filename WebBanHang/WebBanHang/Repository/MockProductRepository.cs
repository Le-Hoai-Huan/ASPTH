using WebBanHang.Models;

namespace WebBanHang.Repository
{
    public class MockProductRepository : IProductReponsitory
    {
        private readonly List<Product> _products;

        public MockProductRepository()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Iphone 12", Price = 1000, Description = "New Iphone 12", CategoryId = 1, ImageUrl="https://images2.thanhnien.vn/528068263637045248/2024/1/25/e093e9cfc9027d6a142358d24d2ee350-65a11ac2af785880-17061562929701875684912.jpg" },
                new Product { Id = 2, Name = "Iphone 11", Price = 900, Description = "New Iphone 11", CategoryId = 1,ImageUrl="https://images2.thanhnien.vn/528068263637045248/2024/1/25/e093e9cfc9027d6a142358d24d2ee350-65a11ac2af785880-17061562929701875684912.jpg" },
                new Product { Id = 3, Name = "Iphone 10", Price = 800, Description = "New Iphone 10", CategoryId = 1,ImageUrl="https://images2.thanhnien.vn/528068263637045248/2024/1/25/e093e9cfc9027d6a142358d24d2ee350-65a11ac2af785880-17061562929701875684912.jpg" },
                new Product { Id = 4, Name = "Samsung Galaxy S21", Price = 1000, Description = "New Samsung Galaxy S21", CategoryId = 2,ImageUrl="https://images2.thanhnien.vn/528068263637045248/2024/1/25/e093e9cfc9027d6a142358d24d2ee350-65a11ac2af785880-17061562929701875684912.jpg" },
                new Product { Id = 5, Name = "Samsung Galaxy S20", Price = 900, Description = "New Samsung Galaxy S20", CategoryId = 2 , ImageUrl = "https://images2.thanhnien.vn/528068263637045248/2024/1/25/e093e9cfc9027d6a142358d24d2ee350-65a11ac2af785880-17061562929701875684912.jpg"},
                new Product { Id = 6, Name = "Samsung Galaxy S10", Price = 800, Description = "New Samsung Galaxy S10", CategoryId = 2, ImageUrl="https://images2.thanhnien.vn/528068263637045248/2024/1/25/e093e9cfc9027d6a142358d24d2ee350-65a11ac2af785880-17061562929701875684912.jpg"},
                new Product { Id = 7, Name = "Macbook Pro 2020", Price = 2000, Description = "New Macbook Pro 2020", CategoryId = 3 },
                new Product { Id = 8, Name = "Macbook Pro 2019", Price = 1800, Description = "New Macbook Pro 2019", CategoryId = 3 },
                new Product { Id = 9, Name = "Macbook Pro 2018", Price = 1600, Description = "New Macbook Pro 2018", CategoryId = 3 },
            };
        }
        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
        public Product GetById (int id)
        {
            return _products.FirstOrDefault(p=>p.Id==id);
        }
        public void Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }
        public void Update(Product product)
        {
            var index = _products.FindIndex(p=>p.Id == product.Id);
            if (index != -1)
            {
                _products[index] = product;
            }
        }
        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product!=null)
            {
                _products.Remove(product);
            }
        }
    }
}
