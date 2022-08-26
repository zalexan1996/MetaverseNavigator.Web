using Microsoft.AspNetCore.Mvc;
using MN.Domain;
using MN.Web.ViewModels;
using MN.Data.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace MN.Web.Controllers
{
    public class PersonaController : PersonaBaseController
    {

        public PersonaController(IPersonaService personaService) : base(personaService) { }


        [HttpGet]
        public IActionResult Index(string confidantFilter = "")
        {

            return View(new PersonaViewModel {
                Confidants =  _personaService.ConfidantRepository.List().Select(a=>a.Name).ToList(),
                Personas =  _personaService.PersonaRepository.GetPersonasWithConfidant(confidantFilter),
                ConfidantFilter = confidantFilter
            });
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public IActionResult AddPersona(string personaName, string confidantName, int startingLevel, string confidantFilter = "")
        {
            if(User.Claims.Single(c=>c.Type == ClaimTypes.Role).Value != "Admin") return Forbid();

            // Add persona to database
             _personaService.PersonaRepository.AddPersona(personaName, confidantName, startingLevel);
             _personaService.PersonaRepository.Save();

            return RedirectToAction("Index", "Persona", new {confidantFilter=confidantFilter});
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public IActionResult RemovePersona(string personaName, string confidantFilter = "")
        {
            if(User.Claims.Single(c=>c.Type == ClaimTypes.Role).Value != "Admin") return Forbid();

            // Add persona to database
             _personaService.PersonaRepository.RemovePersona(personaName);
             _personaService.PersonaRepository.Save();

            return RedirectToAction("Index", new {confidantFilter=confidantFilter});
        }
    }
}