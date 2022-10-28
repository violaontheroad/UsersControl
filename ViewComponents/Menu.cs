using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Test.Models;

namespace UsersControl.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string usersession = HttpContext.Session.GetString("usersessionlogged");

            if (string.IsNullOrEmpty(usersession)) return null;

            User user = JsonConvert.DeserializeObject<User>(usersession);

            return View(user);
        }
    }
}