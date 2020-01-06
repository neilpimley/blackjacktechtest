using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chambers.Partners.Domain.Services;
using Chambers.Partners.WebApi.Mappers;
using Chambers.Partners.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chambers.Partners.WebApi.Controllers
{
    [ApiController]
    public class GamesController : ControllerBase
    {
        private IGameService _gameService;
        private ICardGameMapper _mapper;

        public GamesController(IGameService gameService, ICardGameMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("api/Games/Start")]
        public async Task<IActionResult> StartAsync([FromBody] PlayRequest request)
        {
            try
            {
                var game = await _gameService.StartBlackJack(request.PlayerId);
                return Ok(_mapper.Map(game));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Games/Stick/{gameId}")]
        [HttpPut]
        public async Task<IActionResult> StickAsync(int gameId, [FromBody] PlayRequest request)
        {
            try
            {
                var game = await _gameService.Stick(gameId, request.PlayerId);
                return Ok(_mapper.Map(game));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Games/Hit/{gameId}")]
        [HttpPut]
        public async Task<IActionResult> HitAsync(int gameId, [FromBody] PlayRequest request)
        {
            try
            {
                var game = await _gameService.Hit(gameId, request.PlayerId);
                return Ok(_mapper.Map(game));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
