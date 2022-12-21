using System.ComponentModel.DataAnnotations;

namespace Event.Client.InputModels
{
    public class CitiesInputModel
    {
        [Required]
        public string CityName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Website { get; set; }

        [Required]
        public string PhoneNo { get; set; }

        [Required]
        public IFormFile Image { get; set; }
    }
}
