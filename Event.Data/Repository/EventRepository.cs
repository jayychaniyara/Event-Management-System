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
    public class EventRepository : IEventRepository
    {
        private readonly DBContext dbContext;
        public EventRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Events> GetCompletedEvent()
        {
            return this.dbContext.Events.Where(x => x.IsCompleted == true).ToList();
        }

        public List<Events> GetEventByCurrentMonth(int month)
        {
            return this.dbContext.Events.Where(x=>x.StartDate.Month == month).ToList();
        }

        public List<Events> GetEventById(int id)
        {
            return this.dbContext.Events.Where(x => x.Id == id).ToList();
        }

        public List<Events> GetAll()
        {
            return this.dbContext.Events.ToList();
        }

        public Events AddEvent(Events item)
        {
            this.dbContext.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }
    }
}
