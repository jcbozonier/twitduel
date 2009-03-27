using System;
using TwitDuel.Core.DuelCommands;

namespace TwitDuel.Core
{
    public interface IDuelInterpreter
    {
        TwitterMessage CreateResponse(DuelCommand command);
    }

    public class DuelInterpreter : IDuelInterpreter
    {
        public TwitterMessage CreateResponse(DuelCommand command)
        {
            if(command is DuelStartCommand)
            {
                var duelStart = command as DuelStartCommand;
                var victim = duelStart.Victim;
                var formattedText = String.Format("{0}, do you bite your thumb at {1} in a #ContestOfTwit?",
                                                  duelStart.Victim.screen_name, duelStart.Aggressor.screen_name);
                var message = new TwitterMessage()
                                  {
                                      SendToUsername = victim.screen_name,
                                      Message = formattedText
                                  };

                return message;
            }

            return null;
        }
    }
}
