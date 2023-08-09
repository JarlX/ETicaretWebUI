using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretWebUI.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class HomeController : Controller
    {
        [HttpGet("/Admin/Anasayfa")]
        public IActionResult Index()
        {
            return View();
        }
    }
}