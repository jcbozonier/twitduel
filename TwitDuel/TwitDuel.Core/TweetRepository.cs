using System;
using System.Collections;
using System.Collections.Generic;

namespace TwitDuel.Core
{
    public interface ITweetRepository
    {
        IEnumerable<Tweet> GetTweetsSince(DateTime @checked);
        void Create(string message);
    }

    public class TweetRepository : ITweetRepository
    {
        private ITwitterDataAccess _DataAccess;
        private List<Tweet> _Repo;
        private DateTime _LastChecked;

        public TweetRepository(ITwitterDataAccess dataAccess)
        {
            _DataAccess = dataAccess;
            _Repo = new List<Tweet>();
        }

        public IEnumerable<Tweet> GetTweetsSince(DateTime @checked)
        {
            _LastChecked = @checked;
            var newMessages = _DataAccess.GetMessages();
            _Repo.AddRange(newMessages);
            return newMessages;
        }

        public void Create(string message)
        {
            _DataAccess.SendMessage(message);
        }
    }
}
