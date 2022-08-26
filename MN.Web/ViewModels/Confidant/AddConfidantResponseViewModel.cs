using MN.Domain;
using System.ComponentModel.DataAnnotations;

namespace MN.Web.ViewModels
{
    public class AddConfidantResponseViewModel
    {
        [Required]
        public int ConfidantId {get; set;}

        [Required]
        public int Rank {get; set;}

        [Required]
        public int Order {get; set;}

        [Required]
        public string Response {get; set;} = "";

        public IEnumerable<ConfidantResponses> ExistingResponses { get; set; } = new List<ConfidantResponses>();
        public IEnumerable<ConfidantBenefit> ConfidantBenefits { get; set; } = new List<ConfidantBenefit>();
    }
}