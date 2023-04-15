using CommentProject.BusinessLayer.Abstract;
using CommentProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CommentProject.PresantationLayer.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _categoryService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            category.CategoryStatus = true;
            _categoryService.Add(category);
            return RedirectToAction("Index");
        }
    }
}
