using HeroesApi.Services;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace HeroesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HerosController : ControllerBase
    {
        private readonly HeroesService _heroesService;
        private readonly ILogger<HerosController> _logger;

        public HerosController(
            HeroesService heroesService,
            ILogger<HerosController> logger)
        {
            _heroesService = heroesService;
            _logger = logger;
        }

        [HttpGet("[action]"), ActionName("hero")]
        public async Task<ActionResult<Hero>> GetHero(string id)
        {
            var hero = await _heroesService.FindHero(id);

            if (hero != null)
            {
                _logger.LogInformation(
                    "{name} is {id}",
                    hero.Name,
                    hero.Id);

                return Ok(hero);
            }

            _logger.LogError("Unable to find {hero}", id);
            return NotFound();
        }
    }
}
