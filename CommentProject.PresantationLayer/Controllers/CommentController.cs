using CommentProject.BusinessLayer.Abstract;
using CommentProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CommentProject.PresantationLayer.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITitleService _titleService;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager, ITitleService titleService)
        {
            _commentService = commentService;
            _userManager = userManager;
            _titleService = titleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<SelectListItem> values = (from x in _titleService.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.TitleName,
                                               Value = x.TitleId.ToString()
                                           }).ToList();

            ViewBag.titles = values;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Comment comment)
        {
            comment.CommentStatus = true;
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var commentUserId = await _userManager.FindByNameAsync(User.Identity.Name);
            comment.AppUserId = commentUserId.Id;
            _commentService.Add(comment);
            return RedirectToAction("Index", "Default");
        }

        public async Task<IActionResult> MyComments()
        {
            var commentUserId = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _commentService.GetCommentsByUserWithTitle(commentUserId.Id);
            return View(values);
        }
    }
}
