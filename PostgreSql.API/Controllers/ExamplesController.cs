using Microsoft.AspNetCore.Mvc;
using PostgreSql.Business.Abstract;
using PostgreSql.Entities.Concrate;
using System.Threading.Tasks;

namespace PostgreSql.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamplesController : ControllerBase
    {
        private readonly IExampleService _exampleService;
        public ExamplesController(IExampleService exampleService)
        {
            _exampleService = exampleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _exampleService.GetAllAsync().ConfigureAwait(false);
            if (response != null)
                return Ok(response);
            else
                return NotFound("Örnek veri datası bulunamadı");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _exampleService.GetByIdAsync(id).ConfigureAwait(false);
            if (response != null)
                return Ok(response);
            else
                return NotFound($"{id} Id'sine sahip Örnek veri datası bulunamadı");
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Example example)
        {
            var response = await _exampleService.AddAsync(example).ConfigureAwait(false);
            if (response != null)
                return Ok(response);
            else
                return NotFound("Örnek veri data kaydetme işlemi başarısız");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Example example)
        {
            var response = await _exampleService.UpdateAsync(example).ConfigureAwait(false);
            if (response != null)
                return Ok(response);
            else
                return NotFound("Örnek veri data güncelleme işlemi başarısız");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] Example example)
        {
            var response = await _exampleService.DeleteAsync(example).ConfigureAwait(false);
            if (response != null)
                return Ok(response);
            else
                return NotFound($"{example.Title} isimli Örnek veri datası silinemedi");
        }
    }
}
