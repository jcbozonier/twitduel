using System;
using System.Collections;
using System.Collections.Generic;

namespace TwitDuel.Core
{
    public interface ITweetRepository
    {
        IEnumerable<Tweet> GetTweetsSince(DateTime @checked);
        void Create(Tweet tweet);
    }

    public class TweetRepository : ITweetRepository
    {
        private ITwitterDataAccess _DataAccess;
        private List<Tweet> _Repo;

        public TweetRepository(ITwitterDataAccess dataAccess)
        {
            _DataAccess = dataAccess;
            _Repo = new List<Tweet>();
        }

        public IEnumerable<Tweet> GetTweetsSince(DateTime @checked)
        {
            var newMessages = _DataAccess.GetMessages();
            _Repo.AddRange(newMessages);
            return newMessages;
        }

        public void Create(Tweet tweet)
        {
            throw new NotImplementedException();
        }
    }
}
