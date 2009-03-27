using System;
using NUnit.Framework;
using StructureMap;
using TwitDuel.Core;

namespace TwitDuel.Specs
{
    [TestFixture]
    public class When_a_duel_start_message_is_received_from_twitter
    {
        [Test]
        public void It_should_send_a_message_including_the_victim_and_aggressor()
        {
            var wasMessageSent = false;
            var messageSent = "";
            ContainerBootstrapper.BootstrapStructureMap();

            ObjectFactory.EjectAllInstancesOf<ITwitterDataAccess>();
            ObjectFactory.Inject<ITwitterDataAccess>(
                new FakeDataAccess(() => new[]
                                             {
                                                 new Tweet()
                                                     {
                                                         created_at = DateTime.Now,
                                                         text = "@trvrtzn #ContestOfTwit",
                                                         user = new TwitterUser() {screen_name = "@darkxanthos"}
                                                     }
                                           },
                                           message=>
                                               {
                                                   wasMessageSent = true;
                                                   messageSent = message;
                                                   return message;
                                               }));

            var arena = ObjectFactory.GetInstance<TweetArena>();

            arena.ProcessLatestTweets();
            Assert.IsTrue(wasMessageSent);
            Assert.IsTrue(messageSent.Contains("@trvrtzn"));
            Assert.IsTrue(messageSent.Contains("@darkxanthos"));
            Assert.IsTrue(messageSent.Contains("#ContestOfTwit"));
        }
    }
}
