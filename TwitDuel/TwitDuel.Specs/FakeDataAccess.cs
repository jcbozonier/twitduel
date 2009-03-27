using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitDuel.Core;

namespace TwitDuel.Specs
{
    public class FakeDataAccess : ITwitterDataAccess
    {
        private Func<IEnumerable<Tweet>> _GetMethod;
        private Func<string, string> _SendMethod;

        public FakeDataAccess()
        {
            _GetMethod = () => new List<Tweet>();
            _SendMethod = x => x;
        }

        public FakeDataAccess(Func<IEnumerable<Tweet>> getMethod, Func<string, string> sendMethod)
        {
            _GetMethod = getMethod;
            _SendMethod = sendMethod;
        }

        public string SendMessage(string message)
        {
            return _SendMethod(message);
        }

        public IEnumerable<Tweet> GetMessages()
        {
            return _GetMethod();
        }
    }
}
