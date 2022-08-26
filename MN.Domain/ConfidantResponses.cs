using System.ComponentModel.DataAnnotations;

namespace MN.Domain
{
    public class ConfidantResponses : Persona5Base
    {
        [Required]
        public Confidant? Confidant { get; set; } = null;
        
        [Required]
        public int ConfidantId {get; set;}

        // The rank that this response is associated with.
        [Required]
        public int Rank {get; set;}

        // The order in conversation that this response is relevant
        [Required]
        public int ResponseOrder { get; set; } = 0;

        [Required][MaxLength(250)]
        public string ResponseText { get; set; } = "";

        // This is the number of points that go towards leveling up the social link. Usually 1-3.
        public int BoostAmount { get; set; } = 0;
    }
}
