using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Business.Models
{
    public class TalkDetails
    {
        public int Id { get; set; }

        public int SpeakerId { get; set; }

        public string Title { get; set; }

        public string Room { get; set; }

        public string Description { get; set; }

        public string Talks { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
