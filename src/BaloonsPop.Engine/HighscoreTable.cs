namespace BaloonsPop.Engine
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using BaloonsPop.Common.Contracts;

    public class HighscoreTable : IHighscoreTable
    {
        private const int HighscoreMaxPlayers = 5;
        private List<PlayerScore> table;

        public HighscoreTable()
        {
            this.table = new List<PlayerScore>();
        }

        public List<PlayerScore> Table
        {
            get
            {
                return this.table;
            }
        }

        public bool CanAddPlayer(int movesCount)
        {
            bool listAcceptsEntries = this.table.Count < HighscoreMaxPlayers;
            bool hasLowerMoves = this.table.Any(x => movesCount < x.Moves);

            return listAcceptsEntries || hasLowerMoves;
        }

        public void AddPlayer(PlayerScore score)
        {
            if (this.table.Count == 0)
            {
                this.table.Add(score);
            }
            else
            {
                this.table.Sort();
                var element = this.table.First(x => score.Moves < x.Moves);
                int elementIndex = this.table.IndexOf(element);
                this.table.Insert(elementIndex, score);
            }
        }
    }
}
