using KPMG.Games.Domain.Entities;
using KPMG.Games.Domain.Interfaces.Application;
using KPMG.Games.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KPMG.Games.Application.Application
{
    public class GameResultApplication: ApplicationBase<GameResult>, IGameResultApplication
    {
        private readonly IGameResultService _gameResultService;

        public GameResultApplication(IGameResultService gameResultService):
            base(gameResultService)
        {
            _gameResultService = gameResultService;
        }

        public IEnumerable<GameResult> Leaderboard()
        {
            try
            {
                var listLeaderboard = _gameResultService.GetAll();
                var listaAgrupada = listLeaderboard
                    .GroupBy(x => x.PlayerId)
                    .Select(x => new GameResult
                    {
                        PlayerId = x.First().PlayerId,
                        Win = x.Sum(c => c.Win),
                        Timestamp = LastUpdateDate(x.Where(c => c.PlayerId == x.First().PlayerId))
                    });

                listLeaderboard = listaAgrupada.OrderByDescending(x => x.Win);
                listLeaderboard = listLeaderboard.Take(100);
                return listLeaderboard;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }
            
        }

        public DateTime LastUpdateDate(IEnumerable<GameResult> gameResults)
        {
            var lastUpdateDate = gameResults.OrderByDescending(x => x.Timestamp);
            return lastUpdateDate.FirstOrDefault().Timestamp;
        }

        public void AddGameResultAutoList()
        {
            try
            {
                Random numAleatorio = new Random(18000);
                Random winAleatorio = new Random(180000);
                GameResult gameResult = new GameResult() 
                {
                    GameId = 2,
                    Timestamp = DateTime.Now
                };

                for (int i = 0; i < 1000; i++)
                {
                    gameResult.PlayerId = numAleatorio.Next(1800);
                    gameResult.Win = winAleatorio.Next(18000);
                    gameResult.Id = 0;
                    _gameResultService.AddGameResult(gameResult);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }
        }
    }
}
