using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MN.Data.Services;
using MN.Domain;
using MN.Web.ViewModels;
using System.Security.Claims;


namespace MN.Web.Controllers
{
    public class ConfidantController : PersonaBaseController
    {
        
        public ConfidantController(IPersonaService personaService) : base(personaService) { }


        public IActionResult AddConfidant()
        {

            ViewData["Confidants"] =  _personaService.ConfidantRepository.List().Select(a=>a.Name).ToList();

            return View();
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public IActionResult AddConfidant(string confidantName)
        {
             _personaService.ConfidantRepository.AddConfidant(confidantName);
             _personaService.ConfidantRepository.Save();

            
            ViewData["Confidants"] =  _personaService.ConfidantRepository.List().Select(a=>a.Name).ToList();

            return View();
        }








        public IActionResult ConfidantGuide(int id)
        {
            List<Confidant> confidants = _personaService.ConfidantRepository.List();
            LinkedList<Confidant> confidantList = new LinkedList<Confidant>(confidants);
            Confidant? chosenConfidant = _personaService.ConfidantRepository.GetByIdWithGameCharacter(id);

            var confidantBenefits = _personaService.ConfidantRepository.GetBenefitsByConfidantId(id);
            ConfidantGuideViewModel confidantGuideViewModel = new ConfidantGuideViewModel()
            {
                Confidant = chosenConfidant,
                NextConfidant = chosenConfidant != null ? confidantList.Find(chosenConfidant)?.Next?.Value ?? confidantList.FirstOrDefault() : null,
                PreviousConfidant = chosenConfidant != null ? confidantList.Find(chosenConfidant)?.Previous?.Value ?? confidantList.LastOrDefault() : null,
                ConfidantNames = _personaService.ConfidantRepository.GetConfidantNames(),
                Gifts = null,
                AddConfidantBenefitViewModel = new AddConfidantBenefitViewModel()
                {
                    ExistingBenefits = confidantBenefits,
                    ConfidantId = id
                },
                AddConfidantResponseViewModel = new AddConfidantResponseViewModel()
                {
                    ExistingResponses = _personaService.ConfidantRepository.GetResponsesByConfidantId(id),
                    ConfidantId = id,
                    ConfidantBenefits = confidantBenefits
                }
            };

            return View(confidantGuideViewModel);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddConfidantBenefit(AddConfidantBenefitViewModel benefitVM)
        {
            if (ModelState.ErrorCount >= 1) return RedirectToAction(nameof(ConfidantGuide), new { id = benefitVM.ConfidantId });

            _personaService.ConfidantRepository.AddConfidantBenefit(benefitVM.ConfidantId, benefitVM.AbilityName, benefitVM.Description, benefitVM.RankUnlocked, benefitVM.AdditionalRequirement);
            _personaService.ConfidantRepository.Save();

            return RedirectToAction(nameof(ConfidantGuide), new { id = benefitVM.ConfidantId });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfidantBenefit(int confidantId, string abilityName)
        {

            if (ModelState.Count == 0)
            {
                _personaService.ConfidantRepository.DeleteConfidantBenefit(confidantId, abilityName);
                _personaService.ConfidantRepository.Save();
            }

            return RedirectToAction(nameof(ConfidantGuide), new {Id = confidantId});
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddConfidantResponse(AddConfidantResponseViewModel confidantVM)
        {
            if (ModelState.ErrorCount >= 1) return RedirectToAction(nameof(ConfidantGuide), new { id = confidantVM.ConfidantId });

            _personaService.ConfidantRepository.AddConfidantResponse(confidantVM.ConfidantId, confidantVM.Rank, confidantVM.Order, confidantVM.Response);
            _personaService.ConfidantRepository.Save();

            return RedirectToAction(nameof(ConfidantGuide), new { id = confidantVM.ConfidantId });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfidantResponse(int responseId, int confidantId)
        {

            if (ModelState.ErrorCount == 0)
            {
                _personaService.ConfidantRepository.DeleteConfidantResponse(responseId);
                _personaService.ConfidantRepository.Save();
            }
            return RedirectToAction(nameof(ConfidantGuide), new { id = confidantId });
        }


        [Authorize(Roles = "Admin")]
        public IActionResult EditConfidantBenefit(int id)
        {
            ConfidantBenefit? benefit = _personaService.ConfidantRepository.GetConfidantBenefitById(id);
            return View(benefit);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditConfidantBenefit(ConfidantBenefit benefit)
        {
            // Verify that we passed in a valid ConfidantBenefit with a valid Id.
            ConfidantBenefit ? trackedBenefit = _personaService.ConfidantRepository.GetConfidantBenefitById(benefit.Id);
            if (trackedBenefit != null)
            {
                // Update our fields so that they're being tracked.
                trackedBenefit.AbilityName = benefit.AbilityName;
                trackedBenefit.AdditionalRequirement = benefit.AdditionalRequirement;
                trackedBenefit.Description = benefit.Description;
                trackedBenefit.RankUnlocked = benefit.RankUnlocked;

                // Send our changes to the db
                _personaService.ConfidantRepository.Save();
            }




            return RedirectToAction(nameof(ConfidantGuide), new {id = benefit.ConfidantId});
        }
    }
}