using CommentProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CommentProject.PresantationLayer.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ITitleService _titleService;

        public DefaultController(ITitleService titleService)
        {
            _titleService = titleService;
        }

        public IActionResult Index(int id)
        {
            ViewBag.i = id;
            return View();
        }
    }
}
