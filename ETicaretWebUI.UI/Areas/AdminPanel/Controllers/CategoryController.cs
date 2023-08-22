using Microsoft.AspNetCore.Mvc;

namespace ETicaretWebUI.UI.Areas.AdminPanel.Controllers;

using System.Net;
using ETicaretWEBUI.Core.DTO;
using ETicaretWEBUI.Core.Result;
using ETicaretWEBUI.Helper.SessionHelper;
using Newtonsoft.Json;
using RestSharp;

[Area("AdminPanel")]
public class CategoryController : Controller
{
    [HttpGet("/Admin/Kategori")]
    public async Task<IActionResult> Index()
    {
        var url = "http://localhost:5103/Categories";
        var client = new RestClient(url);

        var request = new RestRequest(url,Method.Get);
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
        RestResponse restResponse = await client.ExecuteAsync(request);
        var responseString = restResponse.Content;

        var responseObject = JsonConvert.DeserializeObject<ApiResult<List<CategoryDTO>>>(responseString);

        var categories = responseObject.Data;
        return View(categories);
    }

    [HttpPost("/AddCategory")]
    public async Task<IActionResult> AddCategory(CategoryDTO categoryDto)
    {
        var url = "http://localhost:5103/AddCategory";
        var client = new RestClient(url);

        var request = new RestRequest(url, Method.Post);
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
        var body = JsonConvert.SerializeObject(categoryDto);
        request.AddBody(body, "application/json");
        RestResponse restResponse = await client.ExecuteAsync(request);

        var responseObject = JsonConvert.DeserializeObject<ApiResult<CategoryDTO>>(restResponse.Content);

        if (restResponse.StatusCode == HttpStatusCode.OK)
        {
            return Json(new { success = true, data = responseObject.Data });
        }

        if (restResponse.StatusCode == HttpStatusCode.BadRequest)
        {
            return Json(new { success = false, HataBilgisi = responseObject.HataBilgsi });
        }
        
        return Json(new { success = false, HataBilgisi = responseObject.HataBilgsi });
    }
}