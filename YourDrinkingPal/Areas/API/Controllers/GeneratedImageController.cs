using BusinessLayer;
using BusinessLayer.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneratedImageController : ControllerBase
    {
        private readonly Service _service;

        public GeneratedImageController(Service service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Webhook(MidjourneyDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _service.GeneratedImage.ProcessImage(dto);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByOriginatingMessageId(int id)
        {
            var image = _service.GeneratedImage.GetByDrinkId(id);
            if (image == null || !image.IsDone) return BadRequest();
            return Ok(image);
        }
    }
}