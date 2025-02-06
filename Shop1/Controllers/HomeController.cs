using Microsoft.AspNetCore.Mvc;

namespace Shop1.Controllers
{
    public class HomeController : Controller
    {
        public RedirectResult Index()
        {
            return Redirect("/Items/List");
        }
    }
}
