using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Yedda;

namespace TwitDuel.Core
{
    public interface ITwitterDataAccess
    {
        string SendMessage(string message);
        IEnumerable<Tweet> GetMessages();
    }

    public class TwitterDataAccess : ITwitterDataAccess
    {
        public string SendMessage(string message)
        {
            var twit = new Twitter
                           {
                               TwitterClient = "Unite",
                               TwitterClientUrl = "http://github.com/jcbozonier/irontwit/tree/master",
                               TwitterClientVersion = "0.1"
                           };

            var result = twit.UpdateAsJSON("JudgingTwit", "110001", message);
            return result;
        }

        public IEnumerable<Tweet> GetMessages()
        {
            var twit = new Twitter
                           {
                               TwitterClient = "Unite",
                               TwitterClientUrl = "http://github.com/jcbozonier/irontwit/tree/master",
                               TwitterClientVersion = "0.1"
                           };

            var result = twit.GetFriendsTimelineAsJSON("JudgingTwit", "110001");

            var str = new StringReader(result);
            var converter = new JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            // Convert the sender property to proper twitter form.
            var tweets = (List<Tweet>)converter.Deserialize(str, typeof(List<Tweet>));

            return tweets;
        }
    }
}
