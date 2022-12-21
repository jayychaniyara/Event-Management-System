using Event.Business.Interface;
using Event.Business.Models;
using Event.Client.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace Event.Client.Controllers
{
    [ApiController]
    [Route("")]
    public class TalkDetailsController : ControllerBase
    {
        private readonly ITalkDetailsRepository talkDetailsRepository;

        public TalkDetailsController(ITalkDetailsRepository talkDetailsRepository)
        {
            this.talkDetailsRepository = talkDetailsRepository;
        }

        //[HttpPost("talkdetails")]
        //public IActionResult AddTalkDetails(TalkDetails item)
        //{
        //    try
        //    {
        //        if (item == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(this.talkDetailsRepository.AddTalkDetails(item));
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpPost("talkdetails")]
        public IActionResult Post([FromForm] TalkdetailsInputModel newTalk, [FromServices] IWebHostEnvironment environment)
        {
            try
            {
                if (newTalk != null)
                {
                    TalkDetails talks = ConvertInputModelToDbModel(newTalk);

                    talkDetailsRepository.AddTalkDetails(talks);
                    return CreatedAtRoute(new { id = talks.Id }, talks);
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

        private static TalkDetails ConvertInputModelToDbModel(TalkdetailsInputModel talkInputModel)
        {
            TalkDetails talks = new()
            {
                SpeakerId = talkInputModel.SpeakerId,
                Title = talkInputModel.Title,
                Room = talkInputModel.Room,
                Description = talkInputModel.Description,
                Talks = talkInputModel.Talks,
                StartTime = talkInputModel.StartTime,
                EndTime = talkInputModel.EndTime,

            };
            return talks;
        }
    }
}
