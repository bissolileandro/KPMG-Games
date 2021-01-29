using KPMG.Games.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPMG.Games.WebApi.Models
{
    public class GamesReultModel
    {        
        public long PlayerId { get; set; }
        public long GameId { get; set; }
        public long Win { get; set; }
        public DateTime Timestamp { get; set; }

        public static GameResult ModelToEntity(GamesReultModel gamesReultModel)
        {
            return new GameResult()
            {
                Id = 0,
                GameId = gamesReultModel.GameId,
                PlayerId = gamesReultModel.PlayerId,
                Timestamp = gamesReultModel.Timestamp,
                Win = gamesReultModel.Win
            };
        }

    }
}
