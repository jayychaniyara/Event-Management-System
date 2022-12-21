using Event.Business.Interface;
using Event.Business.Models;
using Event.Data.MainContext;

namespace Event.Data.Repository
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly DBContext dbContext;
        public CitiesRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Cities AddCity(Cities item)
        {
            this.dbContext.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

        public List<Cities> GetAllVenueOfEventById(int id)
        {
            return (from e in dbContext.Events
                    join c in dbContext.Cities
                    on e.CityId equals c.Id
                    where e.Id == id
                    select c).ToList();
        }

        public Cities GetSpecificVenueDetail(int Eventid, int Cityid)
        {
            return (from e in dbContext.Events
                    join c in dbContext.Cities
                    on e.CityId equals c.Id
                    where e.Id == Eventid && c.Id == Cityid
                    select c).FirstOrDefault();
        }
    }
}
