using System.ComponentModel.DataAnnotations;

namespace Event.Client.InputModels
{
    public class EventInputModel
    {
        [Required]
        public int CityId { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int SpeakerId { get; set; }

        [Required]
        public IFormFile Image { get; set; }
    }
}
