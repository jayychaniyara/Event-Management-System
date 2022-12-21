using Event.Business.Interface;
using Event.Business.Models;
using Event.Client.InputModels;
using Event.Client.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Event.Client.Controllers
{
    [ApiController]
    [Route("")]
    public class VenueController : ControllerBase
    {
        private readonly ICitiesRepository cititesRepository;

        public VenueController(ICitiesRepository cititesRepository)
        {
            this.cititesRepository = cititesRepository;
        }

        [HttpGet("events/{Eventid}/venues/{Cityid}")]
        public IActionResult GetSpecificVenueDetail(int Eventid, int Cityid)
        {
            try
            {
                if(Eventid==null || Cityid==null)
                {
                    return NotFound();
                }
                return Ok(cititesRepository.GetSpecificVenueDetail(Eventid, Cityid));
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("events/{id}/venues")]
        public ActionResult<IEnumerable<VenueViewModel>> GetAllVenueOfEventById(int id)
        {
            try
            {
                IEnumerable<Cities> venues = cititesRepository.GetAllVenueOfEventById(id);

                if (venues == null)
                {
                    return NotFound();
                }

                IEnumerable<VenueViewModel> venueViewModels = convertDbModelToViewModel(venues);
                return Ok(venueViewModels);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private static IEnumerable<VenueViewModel> convertDbModelToViewModel(IEnumerable<Cities> venues)
        {
            ICollection<VenueViewModel> venueViewModels = new List<VenueViewModel>();

            foreach (var item in venues)
            {
                venueViewModels.Add(new VenueViewModel { Address = item.Address, CityName = item.CityName, Image=item.Image, PhoneNo = item.PhoneNo, Website = item.Website});
            }
            return venueViewModels;
        }

        //public IActionResult AddCity(Cities item)
        //{
        //    try
        //    {
        //        if(item == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(this.cititesRepository.AddCity(item));
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpPost("City")]
        public IActionResult Post([FromForm] CitiesInputModel newCity, [FromServices] IWebHostEnvironment environment)
        {
            try
            {
                if (newCity != null)
                {
                    SavePostImageAsync(newCity.Image, environment);
                    Cities city = ConvertInputModelToDbModel(newCity);

                    cititesRepository.AddCity(city);
                    return CreatedAtRoute( new { id = city.Id }, city);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private static Cities ConvertInputModelToDbModel(CitiesInputModel cityInputModel)
        {
            Cities city = new()
            {
                CityName = cityInputModel.CityName,
                Address = cityInputModel.Address,
                Website = cityInputModel.Website,
                PhoneNo = cityInputModel.PhoneNo,
                Image = cityInputModel.Image.FileName,

            };
            return city;
        }

        private static async Task SavePostImageAsync(IFormFile newImage, IWebHostEnvironment environment)
        {
            if (newImage != null)
            {
                var uploadFileName = newImage.FileName;
                var rootPath = Path.Combine(environment.WebRootPath, "CitiesImages");
                var filePath = Path.Combine(rootPath, uploadFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                await newImage.CopyToAsync(new FileStream(filePath, FileMode.Create));
            }
        }
    }
}
