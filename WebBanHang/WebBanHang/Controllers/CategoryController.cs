using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebBanHang.Models;
using WebBanHang.Repository;

namespace WebBanHang.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductReponsitory _productReponsitory;

        public CategoryController(ICategoryRepository categoryRepository, IProductReponsitory productReponsitory)
        {
            _categoryRepository = categoryRepository;
            _productReponsitory = productReponsitory;
        }
        public IActionResult Index()
        {
            var categories = _categoryRepository.GetAllCategories();
            return View(categories);
        }
        public IActionResult Add()
        {
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Update(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Display(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        public IActionResult Delete(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            _categoryRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
