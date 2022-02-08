using System;

namespace Trading.Infrastructure.Data.Model
{
    public class Stock
    {
        public int Id { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }

        public string Exchange { get; set; }

        public string Type { get; set; }

        public string Active { get; set; }

        /**
        public int Id { get; set; }

        public string Symbol { get; set; }

        public string Open { get; set; }

        public string High { get; set; }

        public string Low { get; set; }

        public string Price { get; set; }

        public string Volume { get; set; }

        public string LatestTradingDay { get; set; }

        public string PreviousClose { get; set; }
        **/
    }
}
