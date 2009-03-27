using System;
using System.Collections.Generic;
using TwitDuel.Core.DuelCommands;

namespace TwitDuel.Core
{
    public class TweetArena
    {
        private DateTime _LastChecked;
        private readonly ITweetRepository _TweetRepo;
        private readonly ITweetInterpreter _TweetInterpreter;
        private readonly IDuelInterpreter _DuelInterpreter;

        public TweetArena(ITweetRepository tweetRepo, ITweetInterpreter tweetInterpreter, IDuelInterpreter duelInterpreter)
        {
            _LastChecked = DateTime.MinValue;
            _TweetRepo = tweetRepo;
            _TweetInterpreter = tweetInterpreter;
            _DuelInterpreter = duelInterpreter;
        }

        public void ProcessLatestTweets()
        {
            var tweets = _TweetRepo.GetTweetsSince(_LastChecked);

            var duelCommands = new List<DuelCommand>();
            foreach(var tweet in tweets)
            {
                var duelCommand = _TweetInterpreter.GetDuelCommands(tweet);
                duelCommands.Add(duelCommand);
            }

            var responses = new List<Tweet>();
            foreach(var command in duelCommands)
            {
                var response = _DuelInterpreter.CreateResponse(command);
                responses.Add(response);
            }

            foreach(var response in responses)
            {
                _TweetRepo.Create(response);
            }
        }
    }
}
