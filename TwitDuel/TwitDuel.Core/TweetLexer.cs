using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitDuel.Core.Symbols;

namespace TwitDuel.Core
{
    public class TweetLexer
    {
        private Tweet _Tweet;
        public Symbol CurrentSymbol;
        private int _CurrentIndex;
        private int _EndIndex;

        public TweetLexer(Tweet tweet)
        {
            _Tweet = tweet;
            if(_Tweet.text == null)
                throw new NullReferenceException("The message text should NEVER be null. This is really BAD!");

            _CurrentIndex = 0;
            _EndIndex = tweet.text.Length - 1;
        }

        public Symbol GetNext()
        {
            var currentSymbol = String.Empty;

            while(_CurrentIndex <= _EndIndex)
            {
                var currentChar = _Tweet.text[_CurrentIndex];

                if(currentChar == ' ')
                {
                    _CurrentIndex++;

                    if(_IsSymbol(currentSymbol))
                    {
                        break;
                    }
                    
                    currentSymbol = String.Empty;
                    continue;
                }
                currentSymbol += currentChar;
                
                _CurrentIndex++;
            }

            return _GetSymbol(currentSymbol);
        }

        private Symbol _GetSymbol(string symbol)
        {
            if(symbol.StartsWith("@"))
                return new UserSymbol(symbol);
            if(symbol.StartsWith("#"))
                new TagSymbol(symbol);

            return null;
        }

        private bool _IsSymbol(string symbol)
        {
            return symbol.StartsWith("#") || symbol.StartsWith("@");
        }
    }
}
