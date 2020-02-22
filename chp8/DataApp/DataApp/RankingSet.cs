using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataApp
{
    public class RankingSet
    {
        public int SwimRank = -1;
        public int CycleRank = -1;
        public int RunRank = -1;
        public int OverallRank = -1;
        public int RankCount = -1;

        public RankingSet(IEnumerable<Ranking> sourceParam)
        {
            foreach(Ranking rank in sourceParam)
            {
                switch(rank.Activity)
                {
                    case "Swim":
                        SwimRank = rank.Pos ?? -1;
                        break;
                    case "Cycle":
                        CycleRank = rank.Pos ?? -1;
                        break;
                    case "Run":
                        RunRank = rank.Pos ?? -1;
                        break;
                    case "Overall":
                        OverallRank = rank.Pos ?? -1;
                        break;
                    case "Count":
                        RankCount = rank.Pos ?? -1;
                        break;
                }
            }
        }
    }
}