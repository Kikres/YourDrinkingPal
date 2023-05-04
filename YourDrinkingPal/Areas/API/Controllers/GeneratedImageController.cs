using BusinessLayer.Models.DTO;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneratedImageController : ControllerBase
    {
        private readonly ServiceGeneratedImage _serviceGeneratedImage;

        public GeneratedImageController(ServiceGeneratedImage serviceGeneratedImage)
        {
            _serviceGeneratedImage = serviceGeneratedImage;
        }

        [HttpPost]
        public async Task<IActionResult> Webhook(MidjourneyDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _serviceGeneratedImage.ProcessImage(dto);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByOriginatingMessageId(int id)
        {
            var image = _serviceGeneratedImage.GetByDrinkId(id);
            if (image == null || !image.IsDone) return BadRequest();
            return Ok(image);
        }
    }
}