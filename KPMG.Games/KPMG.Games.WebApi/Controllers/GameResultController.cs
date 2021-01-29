using KPMG.Games.Domain.Interfaces.Application;
using KPMG.Games.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KPMG.Games.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameResultController : ControllerBase
    {
        private readonly IGameResultApplication _gameResultApplication;
        public GameResultController(IGameResultApplication gameResultApplication)
        {
            _gameResultApplication = gameResultApplication;
        }
        // GetLeaderboard: api/<GameResultController>
        [Route("GetLeaderboard")]
        [HttpGet]
        public IActionResult GetLeaderboard()
        {
            try
            {
                var leaderboard = LeaderboardModel.EntityToModel(_gameResultApplication.Leaderboard());
                return Ok(leaderboard);
            }
            catch (Exception e)
            {

                return BadRequest($"Erro: {e.Message}");
            }
            
        }

        // AddGameResult api/<GameResultController>
        [Route("AddGameResult")]
        [HttpPost]
        public IActionResult AddGameResult([FromBody] GamesReultModel gamesReultModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest($"Modelo Inválido");
                }
                _gameResultApplication.AddGameResult(GamesReultModel.ModelToEntity(gamesReultModel));
                return Ok();
                
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
            
        }

        // AddGameResultX api/<GameResultController>
        [Route("AddGameResultX")]
        [HttpPost]
        public IActionResult AddGameResultX([FromBody] GamesReultModel gamesReultModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest($"Modelo Inválido");
                }
                _gameResultApplication.AddGameResultX(GamesReultModel.ModelToEntity(gamesReultModel));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }

    }
}
