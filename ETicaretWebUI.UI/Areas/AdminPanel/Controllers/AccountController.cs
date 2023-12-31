using Microsoft.AspNetCore.Mvc;

namespace ETicaretWebUI.UI.Areas.AdminPanel.Controllers;

using System.Net;
using ETicaretWEBUI.Core.DTO;
using ETicaretWEBUI.Core.Result;
using ETicaretWEBUI.Helper.SessionHelper;
using Newtonsoft.Json;
using RestSharp;

[Area("AdminPanel")]
public class AccountController : Controller
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AccountController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet("/AdminAccount/Login")]
    public IActionResult Index()
    { 
        _httpContextAccessor.HttpContext.Session.Clear();
        return View();
    }

    [HttpPost("/Account/AdminLogin")]
    public async Task<IActionResult> AdminLoginAsync(LoginDTO loginDto)
    {
        var url = "http://localhost:5103/Login";
        var client = new RestClient(url);

        var request = new RestRequest(url, Method.Post);
        request.AddHeader("Content-Type", "application/json");
        var body = JsonConvert.SerializeObject(loginDto);

        request.AddBody(body, "application/json");
        RestResponse restResponse = await client.ExecuteAsync(request);
        var responseString = restResponse.Content;

        var responseObject = JsonConvert.DeserializeObject<ApiResult<LoginDTO>>(responseString);

        if (restResponse.StatusCode == HttpStatusCode.NotFound && responseObject?.Data.Token == null)
        {
            ViewData["LoginError"] = "Kullanıcı Adı Veya Şifre Yanlış.";

            return View("Index");

        }
        if (restResponse.StatusCode != HttpStatusCode.OK)
        {
            ViewData["LoginError"] = "Hata Oluştu";
            return View("Index");
        }
        
        SessionManager.LoggedUser = responseObject.Data;

        return RedirectToAction("Index", "Home");
    }
}