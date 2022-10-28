using Newtonsoft.Json;
using Test.Models;

namespace UsersControl.Helper;



public class UserSession : IUserSession
{
    private readonly IHttpContextAccessor _httpContext;

    public UserSession(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext;
    }

    public User SearchUserSession()
    {
        string usersession = _httpContext.HttpContext.Session.GetString("usersessionlogged");

        if(string.IsNullOrEmpty(usersession)) return null;

        return JsonConvert.DeserializeObject<User>(usersession);
    }

    public void addUserSession(User user)
    {
        string value = JsonConvert.SerializeObject(user);
        _httpContext.HttpContext.Session.SetString("usersessionlogged", value);
    }

    public void removeUserSession()
    {
        _httpContext.HttpContext.Session.Remove("usersessionlogged");
    }

    
}