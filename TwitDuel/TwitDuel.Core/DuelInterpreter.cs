using System;
using TwitDuel.Core.DuelCommands;

namespace TwitDuel.Core
{
    public interface IDuelInterpreter
    {
        Tweet CreateResponse(DuelCommand command);
    }

    public class DuelInterpreter : IDuelInterpreter
    {
        public Tweet CreateResponse(DuelCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
