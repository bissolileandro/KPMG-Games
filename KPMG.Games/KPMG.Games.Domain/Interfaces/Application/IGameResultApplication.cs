using KPMG.Games.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KPMG.Games.Domain.Interfaces.Application
{
    public interface IGameResultApplication: IApplicationBase<GameResult>
    {
        IEnumerable<GameResult> Leaderboard();
        void AddGameResultX(GameResult gameResult);
    }
}
