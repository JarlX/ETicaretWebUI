using Microsoft.AspNetCore.Mvc;

namespace ETicaretWebUI.UI.Areas.AdminPanel.Controllers;

using System.Net;
using ETicaretWEBUI.Core.DTO;
using ETicaretWEBUI.Core.Result;
using Newtonsoft.Json;
using RestSharp;

[Area("AdminPanel")]
public class AccountController : Controller
{
    [HttpGet("/Admin/Login")]
    public IActionResult Index()
    { 
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

        if (restResponse.StatusCode == HttpStatusCode.NotFound && responseObject.Data == null)
        {
            ViewData["LoginError"] = "Kullanıcı Adı Veya Şifre Yanlış.";

            return View("Index");

        }
        if (restResponse.StatusCode != HttpStatusCode.OK)
        {
            ViewData["LoginError"] = "Hata Oluştu";
            return View("Index");
        }

        return RedirectToAction("Index", "Home");
    }
}