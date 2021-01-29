using KPMG.Games.Domain.Entities;
using KPMG.Games.Domain.Interfaces.Repositories;
using KPMG.Games.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace KPMG.Games.Services.Services
{
    public class GameResultService: ServiceBase<GameResult>, IGameResultService
    {
        private readonly IGameResultRepository gameResultRepository;

        public GameResultService(IGameResultRepository gameResultRepository):
            base(gameResultRepository)
        {
            this.gameResultRepository = gameResultRepository;
        }
    }
}
