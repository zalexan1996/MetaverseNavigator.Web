using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MN.Web.Controllers
{
    public abstract class PersonaBaseController : Controller
    {
        protected readonly MN.Data.Services.IPersonaService _personaService;
        public PersonaBaseController(MN.Data.Services.IPersonaService personaService)
        {
            _personaService = personaService;

        }
    }
}