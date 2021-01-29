using KPMG.Games.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.Games.Domain.Interfaces.Application
{
    public interface IGameResultApplication: IApplicationBase<GameResult>
    {
        Task<IEnumerable<GameResult>> Leaderboard();
        void AddGameResultAutoList();
    }
}
