using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Short_URL_System.Dtos;
using Short_URL_System.Interfaces;
using Short_URL_System.Models;
using System.Text;

namespace Short_URL_System.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IMainRepository _mainRepo;
        public MainController(IMainRepository mainRepo)
        {
            _mainRepo = mainRepo;
        }

        [HttpPost("GenerateURL")]
        public async Task<IActionResult> GenerateURL([FromBody] GenerateURLRequestDto urlDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string url = urlDto.URL;
            Random random = new Random();

            while (true)
            {
                StringBuilder randomString = new StringBuilder();
                for (int i = 0; i < 6; i++)
                {
                    randomString.Append(Convert.ToChar(random.Next(65, 90)));
                }
                if (!_mainRepo.IsTextUsed(randomString.ToString()))
                {
                    Website website = new Website() { ShortText = randomString.ToString(), URL = url};
                    await _mainRepo.CreateAsync(website);
                    return Ok($"https://localhost:44335/{randomString.ToString()}");
                }
            }
        }

        [HttpGet]
        [Route("{shortUrlText}")]
        public async Task<IActionResult> RedirectToOriginal([FromRoute] string shortUrlText)
        {
            if (string.IsNullOrWhiteSpace(shortUrlText))
            {
                return BadRequest();
            }
            string? URL = await _mainRepo.GetURLAsync(shortUrlText);
            if(URL == null)
            {
                return NotFound();
            }
            return Redirect(URL);
        }
    }
}
