using Event.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Business.Interface
{
    public interface IEventRepository
    {
        public List<Events> GetEventById(int id);

        public List<Events> GetEventByCurrentMonth(int month);

        public List<Events> GetCompletedEvent();

        public List<Events> GetAll();

        Events AddEvent(Events item);

    }
}
