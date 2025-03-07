using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebBanHang.Models;
using WebBanHang.Repository;

namespace WebBanHang.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductReponsitory _productReponsitory;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductReponsitory productReponsitory, ICategoryRepository categoryRepository)
        {
            _productReponsitory = productReponsitory;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Add()
        {
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        //[HttpPost]
        //public IActionResult Add(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _productReponsitory.Add(product);
        //        return RedirectToAction("Index");
        //    }

        //    return View(product);
        //}
        public IActionResult Index()
        {
            var products = _productReponsitory.GetAll();
            return View(products);
        }
        public IActionResult Display(int id)
        {
            var products = _productReponsitory.GetById(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }
        public IActionResult Update(int id)
        {
            var products = _productReponsitory.GetById(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productReponsitory.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public IActionResult Delete(int id)
        {
            var products = _productReponsitory.GetById(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }
        [HttpPost,ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            _productReponsitory.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Add(Product product, IFormFile
        imageUrl, List<IFormFile> imageUrls)
        {
            if (ModelState.IsValid)
            {
                if (imageUrl != null)
                {
                    // Lưu hình ảnh đại diện
                    product.ImageUrl = await SaveImage(imageUrl);
                }
                if (imageUrls != null)
                {
                    product.ImageUrls = new List<string>();
                    foreach (var file in imageUrls)
                    {
                        // Lưu các hình ảnh khác
                        product.ImageUrls.Add(await SaveImage(file));
                    }
                }
                _productReponsitory.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        private async Task<string> SaveImage(IFormFile image)
        {
            // Thay đổi đường dẫn theo cấu hình của bạn
            var savePath = Path.Combine("wwwroot/images", image.FileName);
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/images/" + image.FileName; // Trả về đường dẫn tương đối
        }
    }

}
