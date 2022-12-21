using Event.Business.Interface;
using Event.Business.Models;
using Event.Client.InputModels;
using Event.Client.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Event.Client.Controllers
{
    [ApiController]
    [Route("")]
    public class SpeakerController : ControllerBase
    {
        private readonly ISpeakerRepository speakerRepository;

        public SpeakerController(ISpeakerRepository speakerRepository)
        {
            this.speakerRepository = speakerRepository;
        }

        [HttpGet("events/{Eventid}/authors/{Speakerid}")]
        public IActionResult GetCompletedTalksBySpecificSpeaker(int Eventid, int Speakerid)
        {
            try
            {
                if(Speakerid == null || Eventid == null)
                {
                    return NotFound();
                }
                return Ok(this.speakerRepository.GetCompletedTalksBySpecificSpeaker(Eventid, Speakerid));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("events/{Eventid}/authors/{Speakerid}/talks")]
        public IActionResult GetTalkOfSpeakerForEvent(int Eventid, int Speakerid)
        {
            try
            {
                if(Eventid == null || Speakerid == null)
                {
                    return NotFound();
                }
                return Ok(this.speakerRepository.GetTalkOfSpeakerForEvent(Eventid, Speakerid));
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet("speaker/{id}")]
        public IActionResult GetSpeakerById(int id)
        {
            try
            {
                if(id == null)
                {
                    return NotFound();
                }
                return Ok(this.speakerRepository.GetSpeakerById(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("events/{id}/authors")]
        public ActionResult<IEnumerable<SpeakerViewModel>> GetSpeakersOfSpecificEvent(int id)
        {
            try
            {
                IEnumerable<Speaker> speakers = speakerRepository.GetSpeakersOfSpecificEvent(id);

                if (speakers == null)
                {
                    return NotFound();
                }

                IEnumerable<SpeakerViewModel> speakerViewModels = convertDbModelToViewModel(speakers);
                return Ok(speakerViewModels);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private static IEnumerable<SpeakerViewModel> convertDbModelToViewModel(IEnumerable<Speaker> speakers)
        {
            ICollection<SpeakerViewModel> speakerViewModels = new List<SpeakerViewModel>();

            foreach (var item in speakers)
            {
                speakerViewModels.Add(new SpeakerViewModel { Name = item.Name, Profile = item.Profile, LinkedInUrl = item.LinkedInUrl, Twitter = item.Twitter, Pic = item.Pic });
            }
            return speakerViewModels;
        }

        //[HttpPost("speaker")]
        //public IActionResult AddSpeaker(Speaker item)
        //{
        //    try
        //    {
        //        if (item == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(this.speakerRepository.AddSpeaker(item));
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpPost("speaker")]
        public IActionResult Post([FromForm] SpeakerInputModel newSpeaker, [FromServices] IWebHostEnvironment environment)
        {
            try
            {
                if (newSpeaker != null)
                {
                    SavePostImageAsync(newSpeaker.Pic, environment);
                    Speaker speaker = ConvertInputModelToDbModel(newSpeaker);

                    speakerRepository.AddSpeaker(speaker);
                    return CreatedAtRoute(new { id = speaker.Id }, speaker);
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

        private static Speaker ConvertInputModelToDbModel(SpeakerInputModel speakerInputModel)
        {
            Speaker speaker = new()
            {
                Name = speakerInputModel.Name,
                Profile = speakerInputModel.Profile,
                LinkedInUrl = speakerInputModel.LinkedInUrl,
                Twitter = speakerInputModel.Twitter,
                Pic = speakerInputModel.Pic.FileName,

            };
            return speaker;
        }

        private static async Task SavePostImageAsync(IFormFile newImage, IWebHostEnvironment environment)
        {
            if (newImage != null)
            {
                var uploadFileName = newImage.FileName;
                var rootPath = Path.Combine(environment.WebRootPath, "SpeakerImages");
                var filePath = Path.Combine(rootPath, uploadFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                await newImage.CopyToAsync(new FileStream(filePath, FileMode.Create));
            }
        }
    }
}
