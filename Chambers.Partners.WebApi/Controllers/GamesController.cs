using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chambers.Partners.Domain.Services;
using Chambers.Partners.WebApi.Mappers;
using Chambers.Partners.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chambers.Partners.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private IGameService _gameService;
        private IPlayerHandMapper _mapper;

        public GamesController(IGameService gameService, IPlayerHandMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        [Route("api/[controller]/start")]
        [HttpPost]
        public async Task<IEnumerable<Card>> StartAsync([FromBody] int playerId)
        {
            var playerHand = await _gameService.StartBlackJack(playerId);
            return playerHand.Select(x => _mapper.Map(x)).ToList();
        }

        [Route("api/[controller]/stick")]
        [HttpPut("{gameId}")]
        public async Task<string> StickAsync(int gameId, [FromBody] int playerId)
        {
            return await _gameService.Stick(gameId, playerId);
        }

        [Route("api/[controller]/hit")]
        [HttpPut("{gameId}")]
        public async Task<IEnumerable<Card>> HitAsync(int gameId, [FromBody] int playerId)
        {
            var playerHand = await _gameService.Hit(gameId, playerId);
            return playerHand.Select(x => _mapper.Map(x)).ToList();
        }
        
    }
}
