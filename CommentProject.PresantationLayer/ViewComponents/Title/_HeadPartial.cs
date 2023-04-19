
using Microsoft.AspNetCore.Mvc;

namespace CommentProject.PresantationLayer.ViewComponents.Title
{
    public class _HeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
