using Microsoft.AspNetCore.Mvc;
using SearchService.Dtos;
using SearchService.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SearchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchRepository _searchRepository;

        public SearchController(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        // GET api/<SearchController>/5
        [HttpGet("{code}")]
        public IActionResult Get(string code)
        {
            try
            {
                var item = _searchRepository.Get(code);
                var dto = new BarcodeDto
                {
                    Code = item.Code,
                    ProductName = item.ProductName,
                    TotalPrice = item.TotalPrice,
                    Volume = item.Volume,
                    Id = item.Id
                };
                if (item == null)
                {
                    return BadRequest();
                }

                var productId=item.ProductId;   
                /////////////
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
