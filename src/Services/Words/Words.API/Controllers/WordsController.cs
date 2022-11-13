using Microsoft.AspNetCore.Mvc;
using System.Net;
using Words.API.Entities;
using Words.API.Repositories;

namespace Words.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public sealed class WordsController : ControllerBase
    {
        private readonly IWordRepository _wordRepository;
        private readonly ILogger<WordsController> _logger;

        public WordsController(IWordRepository wordRepository, ILogger<WordsController> logger)
        {
            _wordRepository = wordRepository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<WordEntity>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult>  GetProductsAsync()
        {
            var products = await _wordRepository.GetWordsAsync();
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> CreateWordAsync([FromBody] WordEntity word)
        {
            await _wordRepository.CreateWord(word);
            return Ok();
        }
    }
}
