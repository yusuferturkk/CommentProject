using CommentProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CommentProject.PresantationLayer.ViewComponents.Title
{
    public class _CommentListByTitle : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _CommentListByTitle(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            ViewBag.titleId = id;
            var values = _commentService.GetCommentsByTitleWithUser(id);
            return View(values);
        }
    }
}
