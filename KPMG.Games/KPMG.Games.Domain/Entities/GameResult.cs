using System;
using System.Collections.Generic;
using System.Text;

namespace KPMG.Games.Domain.Entities
{
    public class GameResult
    {
        public int Id { get; set; }
        public long PlayerId{ get; set; }
        public long GameId { get; set; }
        public long Win { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
