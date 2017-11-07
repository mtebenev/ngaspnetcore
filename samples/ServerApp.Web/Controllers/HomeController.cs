using Microsoft.AspNetCore.Mvc;

namespace ServerApp.Web.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
