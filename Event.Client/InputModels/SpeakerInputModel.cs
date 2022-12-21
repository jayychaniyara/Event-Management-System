using System.ComponentModel.DataAnnotations;

namespace Event.Client.InputModels
{
    public class SpeakerInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Profile { get; set; }

        [Required]
        public string LinkedInUrl { get; set; }

        [Required]
        public string Twitter { get; set; }

        [Required]
        public IFormFile Pic { get; set; }
    }
}
