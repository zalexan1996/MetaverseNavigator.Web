using MN.Domain;

namespace MN.Web.ViewModels
{
    public class ConfidantGuideViewModel
    {
        public List<string> ConfidantNames = new List<string>();
        public Confidant? Confidant;
        public AddConfidantBenefitViewModel AddConfidantBenefitViewModel = new AddConfidantBenefitViewModel();
        public AddConfidantResponseViewModel AddConfidantResponseViewModel = new AddConfidantResponseViewModel();
        public List<ConfidantGift>? Gifts;

        public Confidant? NextConfidant;
        public Confidant? PreviousConfidant;
    }
}