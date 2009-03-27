using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitDuel.Core
{
    public class Tweet
    {
        public string text { get; set; }
        public DateTime created_at { get; set; }
        public TwitterUser user { get; set; }
    }
}
