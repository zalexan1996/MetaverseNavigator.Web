using System.ComponentModel.DataAnnotations;

namespace MN.Domain
{
    public class ConfidantGift : Persona5Base
    {

        // The confidant that this gift is for.

        [Required]
        public Confidant? Confidant { get; set; } = null;

        // The gift item that this corresponds to.
        [Required]
        public GameItem? GameItem { get; set; } = null;

        // The amount of points that you get from gifting this gift.
        public int GiftScore { get; set; } = 0;

    }
}
