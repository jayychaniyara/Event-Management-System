using Event.Business.Interface;
using Event.Business.Models;
using Event.Data.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Data.Repository
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly DBContext dbContext;
        public SpeakerRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public TalkDetails GetCompletedTalksBySpecificSpeaker(int Eventid,int Speakerid)
        {
            return (from e in this.dbContext.Events
                    join s in this.dbContext.Speaker
                    on e.SpeakerId equals s.Id
                    join t in this.dbContext.TalkDetails
                    on s.Id equals t.SpeakerId
                    where e.Id == Eventid
                    && s.Id == Speakerid
                    && e.IsCompleted == true
                    select t).FirstOrDefault();
        }

        public List<Speaker> GetSpeakersOfSpecificEvent(int id)
        {
            return (from s in this.dbContext.Speaker
                    join e in this.dbContext.Events
                    on s.Id equals e.SpeakerId
                    where e.Id == id
                    select s).ToList();
            //return this.dbContext.Speaker.Where(x => x.Id == id).ToList();


        }

        public TalkDetails GetTalkOfSpeakerForEvent(int Eventid, int Speakerid)
        {
            return (from e in this.dbContext.Events
                    join s in this.dbContext.Speaker
                    on e.SpeakerId equals s.Id
                    join t in this.dbContext.TalkDetails
                    on s.Id equals t.SpeakerId
                    where e.Id == Eventid
                    && s.Id == Speakerid
                    select t).FirstOrDefault();
        }

        public List<Speaker> GetSpeakerById(int id)
        {
            return this.dbContext.Speaker.Where(s => s.Id == id).ToList();
        }

            public Speaker AddSpeaker(Speaker item)
            {
                this.dbContext.Add(item);
                this.dbContext.SaveChanges();
                return item;
            }
    }
}
