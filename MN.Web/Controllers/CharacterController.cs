using Microsoft.AspNetCore.Mvc;
using MN.Data.Services;
using MN.Domain;
using MN.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace MN.Web.Controllers
{
    public class CharacterController : PersonaBaseController
    {

        public CharacterController(IPersonaService personaService) : base(personaService) { }

        public IActionResult Index()
        {
            // Dump our BattleCharacters and include the GameCharacter link
            // TODO: Add GameCharacterId to BattleCharacter sos I don't have to add this link.
            IEnumerable<BattleCharacter> battleCharacters = _personaService.BattleCharacterRepository.ListWithGameCharacter(b=>true);


            IEnumerable<CharacterBundle> characterBundles = _personaService.GameCharacterRepository.List().Select(g=> new CharacterBundle()
            {
                BattleCharacter = battleCharacters.SingleOrDefault(b=>b.GameCharacter?.Id == g.Id),
                GameCharacter = g,
                Confidant = _personaService.ConfidantRepository.GetConfidantByGameCharacter(g.Id)
            });

            
            return View(new CharacterViewModel()
            {
                CharacterBundles = characterBundles
            });
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCharacter(int gameCharacterId)
        {
            // exit prematurely if the id is invalid
            if (gameCharacterId < 0) return RedirectToAction("Index");


            // Delete the battle character first if there is one.
            BattleCharacter? battleCharacter = _personaService.BattleCharacterRepository.FindByGameCharacterId(gameCharacterId);
            

            if (battleCharacter != null)
            {
                _personaService.BattleCharacterRepository.DeleteById(battleCharacter.Id);
                _personaService.BattleCharacterRepository.Save();
            }
            
            // Remove the confidant relationship with this game character if there is one.
            Confidant? confidant = _personaService.ConfidantRepository.GetConfidantByGameCharacter(gameCharacterId);
            if (confidant != null)
            {
                confidant.GameCharacterId = null;
                confidant.GameCharacter = null;
                 _personaService.ConfidantRepository.Save();
            }

            

            // Delete the Game character
             _personaService.GameCharacterRepository.DeleteById(gameCharacterId);

            // Save changes to the database
             _personaService.GameCharacterRepository.Save();
            
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddCharacter()
        {

            AddCharacterViewModel addCharacterViewModel = new AddCharacterViewModel()
            {
                Confidants =  _personaService.ConfidantRepository.List(),
                Personas =  _personaService.PersonaRepository.List(),
                MeleeWeaponTypes =  _personaService.MeleeWeaponTypeRepository.List().Select(m=>m.Name),
                RangedWeaponTypes =  _personaService.RangedWeaponTypeRepository.List().Select(r=>r.Name)
            };

            return View(addCharacterViewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult EditCharacter(int id)
        {

            // Exit prematurely if there isn't a character with this id.
            GameCharacter? gameCharacter = _personaService.GameCharacterRepository.GetById(id);
            if (gameCharacter == null) return RedirectToAction(nameof(Index));


            // Prefill the base fields
            AddCharacterViewModel addCharacterViewModel = new AddCharacterViewModel()
            {
                Confidants =  _personaService.ConfidantRepository.List(),
                Personas =  _personaService.PersonaRepository.List(),
                MeleeWeaponTypes =  _personaService.MeleeWeaponTypeRepository.List().Select(m=>m.Name),
                RangedWeaponTypes =  _personaService.RangedWeaponTypeRepository.List().Select(r=>r.Name),

                Name = gameCharacter.Name,
                Age = gameCharacter.Age,
                Occupation = gameCharacter.Occupation
            };

            // Prefill the BattleCharacter fields
            BattleCharacter? battleCharacter = _personaService.BattleCharacterRepository.FindByGameCharacterIdIncludeAll(id);
            if (battleCharacter != null)
            {
                addCharacterViewModel.IsBattleCharacter = true;
                addCharacterViewModel.AwakenedPersonaName = battleCharacter.AwakenedPersona?.Name;
                addCharacterViewModel.StartingPersonaName = battleCharacter.BasePersona?.Name;
                addCharacterViewModel.Codename = battleCharacter.Codename;
                addCharacterViewModel.MeleeWeaponTypeName = battleCharacter?.MeleeWeaponType?.Name;
                addCharacterViewModel.RangedWeaponTypeName = battleCharacter?.RangedWeaponType?.Name;
            }

            // Prefill the confidant fields
            Confidant? confidant = _personaService.ConfidantRepository.GetConfidantByGameCharacter(id);
            if (confidant != null)
            {
                addCharacterViewModel.IsConfidantCharacter = true;
                addCharacterViewModel.ConfidantName = confidant.Name;
            }

            
            return RedirectToAction(nameof(AddCharacter), addCharacterViewModel);
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCharacter(AddCharacterViewModel viewModel)
        {            

            viewModel.Confidants =  _personaService.ConfidantRepository.List();
            viewModel.Personas =  _personaService.PersonaRepository.List();
            viewModel.MeleeWeaponTypes =  _personaService.MeleeWeaponTypeRepository.List().Select(m=>m.Name);
            viewModel.RangedWeaponTypes =  _personaService.RangedWeaponTypeRepository.List().Select(r=>r.Name);

            // Exit prematurely if there are binding or validation errors
            if (ModelState.ErrorCount >= 1) return View(viewModel);


             _personaService.GameCharacterRepository.Add(new GameCharacter(){
                Age = viewModel.Age,
                Name = viewModel.Name,
                Occupation = viewModel.Occupation
            });

             _personaService.GameCharacterRepository.Save();


            if (viewModel.IsBattleCharacter)
            {


                MeleeWeaponType? meleeTypeObj =  _personaService.MeleeWeaponTypeRepository.GetWeaponTypeByName(viewModel.MeleeWeaponTypeName);
                RangedWeaponType? rangedTypeObj =  _personaService.RangedWeaponTypeRepository.GetWeaponTypeByName(viewModel.RangedWeaponTypeName);
                GameCharacter? gameCharacterObj =  _personaService.GameCharacterRepository.GetGameCharacterByName(viewModel.Name);
                Confidant? confidantObj =  _personaService.ConfidantRepository.GetConfidantByName(viewModel.ConfidantName);
                Persona? basePersonaObj =  _personaService.PersonaRepository.GetPersonaByName(viewModel.StartingPersonaName);
                Persona? awakenedPersonaObj =  _personaService.PersonaRepository.GetPersonaByName(viewModel.AwakenedPersonaName);


                // Add a new Battle character to the database.
                 _personaService.BattleCharacterRepository.Add(new BattleCharacter {
                    Codename = viewModel.Codename,
                    MeleeWeaponTypeId = meleeTypeObj.Id,
                    RangedWeaponTypeId = rangedTypeObj.Id,
                    GameCharacterId = gameCharacterObj.Id,
                    BasePersonaId = basePersonaObj.Id,
                    AwakenedPersonaId = awakenedPersonaObj.Id
                });

                 _personaService.BattleCharacterRepository.Save();
            }

            if (viewModel.IsConfidantCharacter)
            {
                Confidant? confidantObj =  _personaService.ConfidantRepository.GetConfidantByName(viewModel.ConfidantName);
                GameCharacter? gameCharacterObj =  _personaService.GameCharacterRepository.GetGameCharacterByName(viewModel.Name);

                confidantObj.GameCharacterId = gameCharacterObj.Id;

                 _personaService.ConfidantRepository.Save();
            }

            return RedirectToAction("Index", "Character");
        }
    }
}