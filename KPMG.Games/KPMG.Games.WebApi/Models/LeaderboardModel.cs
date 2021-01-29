using KPMG.Games.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPMG.Games.WebApi.Models
{
    public class LeaderboardModel
    {        
        public long PlayerId { get; set; }
        public long Balance { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public static IEnumerable<LeaderboardModel> EntityToModel(IEnumerable<GameResult> gameResults)
        {
            var listModel = new List<LeaderboardModel>();
            foreach (var item in gameResults)
            {
                var addItem = new LeaderboardModel()
                {
                    PlayerId = item.PlayerId,
                    Balance = item.Win,
                    LastUpdateDate = item.Timestamp
                };
                listModel.Add(addItem);
            }
            return listModel.ToList();
        }
    }
}
