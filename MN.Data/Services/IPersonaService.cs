namespace MN.Data.Services
{
    public interface IPersonaService
    {
        UserRepository UserRepository {get;}
        BattleCharacterRepository BattleCharacterRepository {get;}
        ConfidantRepository ConfidantRepository {get;}
        GameCharacterRepository GameCharacterRepository {get;}
        MeleeWeaponTypeRepository MeleeWeaponTypeRepository {get;}
        PersonaRepository PersonaRepository {get;}
        RangedWeaponTypeRepository RangedWeaponTypeRepository {get;}
    }


    public class PersonaService : IPersonaService
    {
        public PersonaService()
        {
            _userRepository = new UserRepository();
            _battleCharacterRepository = new BattleCharacterRepository();
            _confidantRepository = new ConfidantRepository();
            _gameCharacterRepository = new GameCharacterRepository();
            _meleeWeaponTypeRepository = new MeleeWeaponTypeRepository();
            _personaRepository = new PersonaRepository();
            _rangedWeaponTypeRepository = new RangedWeaponTypeRepository();
        }

        
        // Repository Properties
        public UserRepository UserRepository => _userRepository;
        public BattleCharacterRepository BattleCharacterRepository => _battleCharacterRepository;
        public ConfidantRepository ConfidantRepository => _confidantRepository;
        public GameCharacterRepository GameCharacterRepository => _gameCharacterRepository;
        public MeleeWeaponTypeRepository MeleeWeaponTypeRepository => _meleeWeaponTypeRepository;
        public PersonaRepository PersonaRepository => _personaRepository;
        public RangedWeaponTypeRepository RangedWeaponTypeRepository => _rangedWeaponTypeRepository;


        // Fields
        protected UserRepository _userRepository;
        protected BattleCharacterRepository _battleCharacterRepository;
        protected ConfidantRepository _confidantRepository;
        protected GameCharacterRepository _gameCharacterRepository;
        protected MeleeWeaponTypeRepository _meleeWeaponTypeRepository;
        protected PersonaRepository _personaRepository;
        protected RangedWeaponTypeRepository _rangedWeaponTypeRepository;

    }
}