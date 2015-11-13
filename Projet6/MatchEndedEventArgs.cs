using System;

namespace Projet6
{
    public class MatchEndedEventArgs : EventArgs
    {
        public Match Match { get; private set; }

        public MatchEndedEventArgs(Match match)
        {
            this.Match = new Match(match);
        }
    }
}