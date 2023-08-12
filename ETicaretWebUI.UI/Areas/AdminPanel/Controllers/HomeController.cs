using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretWebUI.UI.Areas.AdminPanel.Controllers
{
    using ETicaretWEBUI.Core.ViewModel;

    [Area("AdminPanel")]
    public class HomeController : Controller
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet("/Admin/Anasayfa")]
        public IActionResult Index()
        {

            UserViewModel userViewModel = new UserViewModel()
            {
                FullName = _httpContextAccessor.HttpContext.Session.GetString("User")

            };
            
            return View(userViewModel);
        }
    }
}