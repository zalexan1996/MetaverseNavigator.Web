using MN.Domain;

namespace MN.Web.ViewModels
{
    public class AddConfidantBenefitViewModel
    {
        public IEnumerable<ConfidantBenefit> ExistingBenefits = new List<ConfidantBenefit>();

        public int ConfidantId {get; set;}
        public string AbilityName {get; set;} = "";
        public int RankUnlocked {get; set;}
        public string Description {get; set;} = "";
        public string AdditionalRequirement {get; set;} = "";

    }
}