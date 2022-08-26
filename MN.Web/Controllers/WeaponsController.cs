using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MN.Data.Services;
using System.Data;
using System.Security.Claims;


namespace MN.Web.Controllers
{
    public class WeaponsController : PersonaBaseController
    {
        
        public WeaponsController(IPersonaService personaService) : base(personaService) { }


        public IActionResult AddWeaponType()
        {

            ViewData["MeleeWeaponTypes"] =  _personaService.MeleeWeaponTypeRepository.GetAllTypes();
            ViewData["RangedWeaponTypes"] =  _personaService.RangedWeaponTypeRepository.GetAllTypes();
            return View();
        }



        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public IActionResult AddMeleeWeaponType(string newName)
        {
            
            if(User.Claims.Single(c=>c.Type == ClaimTypes.Role).Value != "Admin") return Forbid();

             _personaService.MeleeWeaponTypeRepository.AddWeaponType(newName);
             _personaService.MeleeWeaponTypeRepository.Save();
            
            return RedirectToAction(nameof(AddWeaponType));
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public IActionResult AddRangedWeaponType(string newName)
        {
            
            if(User.Claims.Single(c=>c.Type == ClaimTypes.Role).Value != "Admin") return Forbid();

             _personaService.RangedWeaponTypeRepository.AddWeaponType(newName);
             _personaService.RangedWeaponTypeRepository.Save();
            
            return RedirectToAction(nameof(AddWeaponType));
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveMeleeWeaponType(string type)
        {
            
            if(User.Claims.Single(c=>c.Type == ClaimTypes.Role).Value != "Admin") return Forbid();

             _personaService.MeleeWeaponTypeRepository.RemoveByName(type);
             _personaService.MeleeWeaponTypeRepository.Save();

            return RedirectToAction(nameof(AddWeaponType));
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveRangedWeaponType(string type)
        {
            
            if(User.Claims.Single(c=>c.Type == ClaimTypes.Role).Value != "Admin") return Forbid();

             _personaService.RangedWeaponTypeRepository.RemoveByName(type);
             _personaService.RangedWeaponTypeRepository.Save();

            return RedirectToAction(nameof(AddWeaponType));
        }
     }
}