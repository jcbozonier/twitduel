using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitDuel.Core.DuelCommands
{
    public class DuelStartCommand : DuelCommand
    {
        public TwitterUser Aggressor { get; private set; }
        public TwitterUser Victim { get; private set; }

        public DuelStartCommand(TwitterUser victim, TwitterUser aggressor)
        {
            Victim = victim;
            Aggressor = aggressor;
        }
    }
}
