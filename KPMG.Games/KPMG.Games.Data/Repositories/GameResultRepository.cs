using KPMG.Games.Domain.Entities;
using KPMG.Games.Domain.Interfaces.Repositories;
using KPMG.Games.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace KPMG.Games.Infra.Data.Repositories
{
    public class GameResultRepository : RepositoryBase<GameResult>, IGameResultRepository
    {
        public GameResultRepository(KPGMGamesContext kPGMGamesContext) :
            base(kPGMGamesContext)
        {

        }
    }
}
