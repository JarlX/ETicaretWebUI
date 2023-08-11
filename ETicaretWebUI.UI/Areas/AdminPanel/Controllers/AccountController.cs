using Microsoft.AspNetCore.Mvc;

namespace ETicaretWebUI.UI.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]
public class AccountController : Controller
{
    [HttpGet("/adminLogin")]
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> LoginAsync()
    {
        
    }
}