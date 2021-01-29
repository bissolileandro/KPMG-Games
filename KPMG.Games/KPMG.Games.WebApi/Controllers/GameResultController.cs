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
        public async Task<IActionResult> GetLeaderboard()
        {
            try
            {
                var leaderboard = LeaderboardModel.EntityToModel(await _gameResultApplication.Leaderboard());
                
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
        public IActionResult AddGameResult([FromBody] IEnumerable<GamesReultModel> gamesReultsModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest($"Erro no modelo informado");
                 _gameResultApplication.AddGameResult(GamesReultModel.ModelToEntityList(gamesReultsModel.ToArray()));
                return Ok();
                
                
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
            
        }

        // AddGameResultAutoList api/<GameResultController>
        [Route("AddGameResultAutoList")]
        [HttpPost]
        public IActionResult AddGameResultAutoList()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest($"Modelo Inválido");
                }
                _gameResultApplication.AddGameResultAutoList();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }

    }
}
