using CommentProject.BusinessLayer.Abstract;
using CommentProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CommentProject.PresantationLayer.Controllers
{
    public class TitleController : Controller
    {

        private readonly ITitleService _titleService;
        private readonly ICategoryService _categoryService;

        public TitleController(ITitleService titleService, ICategoryService categoryService)
        {
            _titleService = titleService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _titleService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTitle()
        {
            List<SelectListItem> values = (from x in _categoryService.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();

            ViewBag.categories = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddTitle(Title title)
        {
            return View();
        }
    }
}
