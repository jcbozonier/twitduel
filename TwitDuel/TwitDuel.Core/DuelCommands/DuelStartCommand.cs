using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitDuel.Core.DuelCommands
{
    public class DuelStartCommand : DuelCommand
    {
        private TwitterUser _Victim;

        public DuelStartCommand(TwitterUser victim)
        {
            _Victim = victim;
        }
    }
}
