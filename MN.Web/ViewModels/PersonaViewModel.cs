using MN.Domain;

namespace MN.Web.ViewModels
{
    public class PersonaViewModel
    {
        public IEnumerable<Persona> Personas = new List<Persona>();
        public IEnumerable<string> Confidants = new List<string>();
        public string ConfidantFilter = "";

    }
}