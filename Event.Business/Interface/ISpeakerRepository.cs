using Event.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Business.Interface
{
    public interface ISpeakerRepository
    {
        public List<Speaker> GetSpeakersOfSpecificEvent(int id);

        public TalkDetails GetTalkOfSpeakerForEvent(int Eventid, int Speakerid);

        public TalkDetails GetCompletedTalksBySpecificSpeaker(int Eventid,int Speakerid);

        public List<Speaker> GetSpeakerById(int id);

        Speaker AddSpeaker(Speaker item);

    }
}
