using System.ComponentModel.DataAnnotations;

namespace Event.Client.InputModels
{
    public class TalkdetailsInputModel
    {
        [Required]
        public int SpeakerId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Room { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Talks { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
    }
}
