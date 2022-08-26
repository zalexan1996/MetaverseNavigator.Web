using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MN.Web.Controllers
{
    public class HomeController : PersonaBaseController
    {
        public HomeController(MN.Data.Services.IPersonaService personaService) : base(personaService) { }
        public IActionResult Index()
        {
            return View();
        }
    }
}