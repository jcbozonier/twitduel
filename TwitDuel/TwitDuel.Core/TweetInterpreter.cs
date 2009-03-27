using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitDuel.Core.DuelCommands;
using TwitDuel.Core.Symbols;

namespace TwitDuel.Core
{
    public interface ITweetInterpreter
    {
        DuelCommand GetDuelCommands(Tweet tweet);
    }

    public class TweetInterpreter : ITweetInterpreter
    {
        public TweetInterpreter()
        {
        }


        public DuelCommand GetDuelCommands(Tweet tweet)
        {
            var tweetLexer = new TweetLexer(tweet);

            var symbolList = new List<Symbol>();

            while(tweetLexer.GetNext() != null)
            {
                var currentSymbol = tweetLexer.CurrentSymbol;
                if (currentSymbol != null)
                    symbolList.Add(currentSymbol);
            }

            var symbolInterpreter = new SymbolInterpreter();
            if (symbolInterpreter.IsDuelStart(symbolList))
            {
                var victim = symbolList.Single(symbol => symbol is UserSymbol) as UserSymbol;
                return new DuelStartCommand(new TwitterUser() {screen_name = victim.Name});
            }

            return new DoNothingDuelCommand();
        }
    }
}
