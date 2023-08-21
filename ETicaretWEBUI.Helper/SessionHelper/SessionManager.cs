namespace ETicaretWEBUI.Helper.SessionHelper;

using Core.DTO;
using Core.ViewModel;
using Microsoft.AspNetCore.Http;

public class SessionManager
{
    public static LoginDTO? LoggedUser
    {
        get => AppHttpContext.CurrentContext.Session.GetObject<LoginDTO>("LoginDTO");
        set => AppHttpContext.CurrentContext.Session.SetObject("LoginDTO", value);
    }

    public static UserViewModel UserViewModel
    {
        get => AppHttpContext.CurrentContext.Session.GetObject<UserViewModel>("UserViewModel");
        set => AppHttpContext.CurrentContext.Session.SetObject("UserViewModel", value);
    }
}