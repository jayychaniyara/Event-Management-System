namespace Event.Client.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }
       
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CityId { get; set; }

        public int SpeakerId { get; set; }

    }
}
