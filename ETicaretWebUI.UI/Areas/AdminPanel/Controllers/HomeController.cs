using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretWebUI.UI.Areas.AdminPanel.Controllers
{
    using ETicaretWEBUI.Core.ViewModel;
    using ETicaretWEBUI.Helper.SessionHelper;

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
                FullName = SessionManager.LoggedUser.FullName,
                
                UserId = SessionManager.LoggedUser.UserId,
                
                Email = SessionManager.LoggedUser.Email,
                
                Address = SessionManager.LoggedUser.Address

            };
            
            return View(userViewModel);
        }
    }
}