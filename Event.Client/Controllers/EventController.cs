using Event.Business.Interface;
using Event.Business.Models;
using Event.Client.InputModels;
using Event.Client.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Event.Client.Controllers
{
    [ApiController]
   
    public class EventController : ControllerBase
    {
        private readonly IEventRepository eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        [HttpGet("events/{id}")]
        public IActionResult GetEventById(int id)
        {
            try
            {
                if(id == null)
                {
                    return NotFound();
                }

                return Ok(this.eventRepository.GetEventById(id));
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet("event/{month}")]
        public IActionResult GetEventByCurrentMonth(int month)
        {
            try
            {
                if(month == null)
                {
                    return NotFound();
                }
                return Ok(this.eventRepository.GetEventByCurrentMonth(month));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("events/completed")]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<Events> events = eventRepository.GetAll();

                if (events == null)
                {
                    return NotFound();
                }

                IEnumerable<EventViewModel> eventViewModels = convertDbModelToViewModel(events);
                return Ok(eventViewModels);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private static IEnumerable<EventViewModel> convertDbModelToViewModel(IEnumerable<Events> events)
        {
            ICollection<EventViewModel> eventViewModels = new List<EventViewModel>();

            foreach (var item in events)
            {
                eventViewModels.Add(new EventViewModel { Id = item.Id, StartDate = item.StartDate, Name = item.Name, Image = item.Image , EndDate = item.EndDate , CityId = item.CityId , SpeakerId = item.SpeakerId });
            }
            return eventViewModels;
        }

        //[HttpPost("event")]
        //public IActionResult AddEvent(Events item)
        //{
        //    try
        //    {
        //        if (item == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(this.eventRepository.AddEvent(item));
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpPost("event")]
        public IActionResult Post([FromForm] EventInputModel newEvent, [FromServices] IWebHostEnvironment environment)
        {
            try
            {
                if (newEvent != null)
                {
                    SavePostImageAsync(newEvent.Image, environment);
                    Events events = ConvertInputModelToDbModel(newEvent);

                    eventRepository.AddEvent(events);
                    return CreatedAtRoute(new { id = events.Id }, events);
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

        private static Events ConvertInputModelToDbModel(EventInputModel eventInputModel)
        {
            Events events = new()
            {
                CityId = eventInputModel.CityId,
                Address = eventInputModel.Address,
                StartDate = eventInputModel.StartDate,
                EndDate = eventInputModel.EndDate,
                IsCompleted = eventInputModel.IsCompleted,
                Name = eventInputModel.Name,
                Description = eventInputModel.Description,
                SpeakerId = eventInputModel.SpeakerId,
                Image = eventInputModel.Image.FileName,

            };
            return events;
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
