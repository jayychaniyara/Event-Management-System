using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Business.Models
{
    public class Events
    {
        public int Id { get; set; }

        public int CityId { get; set; }
        
        public string Address { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public bool IsCompleted { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public int SpeakerId { get; set; }

        public string Image { get; set; }

    }
}
