using Event.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Business.Interface
{
    public interface ICitiesRepository
    {
        public List<Cities> GetAllVenueOfEventById(int id);

        public Cities GetSpecificVenueDetail(int Eventid, int Cityid);

        Cities AddCity(Cities item);
    }
}
