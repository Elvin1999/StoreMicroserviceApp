using ImageServiceApi.Dtos;
using ImageServiceApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private IPhotoService _photoService;

        public ImageController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        // POST api/<ImageController>
        [HttpPost]
        public IActionResult Post([FromBody] PhotoCreationDto dto)
        {
            try
            {
                
                var result=_photoService.UploadImage(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
