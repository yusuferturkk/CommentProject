using CommentProject.EntityLayer.Concrete;
using CommentProject.PresantationLayer.Models.AppUserViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CommentProject.PresantationLayer.Controllers
{
	public class RegisterController : Controller
	{

		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(RegisterViewModel model)
		{
			var appUser = new AppUser()
			{
				Name = model.Name,
				Surname = model.Surname,
				Email = model.Email,
				UserName = model.UserName,
				Image = "Test"
			};
			if (model.Password == model.ConfirmPassword)
			{
				var result = await _userManager.CreateAsync(appUser, model.Password);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Login");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			else
			{
				ModelState.AddModelError("", "Şifreler birbiri ile uyuşmuyor!");
			}
			return View();
		}
	}
}
