using System;
using NUnit.Framework;
using StructureMap;
using TwitDuel.Core;

namespace TwitDuel.Specs
{
    [TestFixture]
    public class When_a_duel_start_message_is_received_from_twitter : duel_start_with_one_message_waiting_context
    {
        [Test]
        public void It_should_send_a_message()
        {   
            Assert.IsTrue(WasMessageSent);
        }

        [Test]
        public void It_should_include_the_victim()
        {
            Assert.IsTrue(MessageSent.Contains(VictimName));
        }

        [Test]
        public void It_should_include_the_aggressor()
        {
            Assert.IsTrue(MessageSent.Contains(AggressorName));
        }

        [Test]
        public void It_should_include_the_twitter_tag()
        {
            Assert.IsTrue(MessageSent.Contains(TwitterTag));
        }

        [Test]
        public void It_should_be_under_the_twitter_size_limit()
        {
            Assert.IsTrue(MessageSent.Length < 140);
        }

        protected override void Because()
        {
            _Arena.ProcessLatestTweets();
        }

        protected override void Context()
        {
            ObjectFactory.EjectAllInstancesOf<ITwitterDataAccess>();
            ObjectFactory.Inject<ITwitterDataAccess>(
                new FakeDataAccess(() => new[]
                                             {
                                                 new Tweet()
                                                     {
                                                         created_at = DateTime.Now,
                                                         text = VictimName + " " + TwitterTag,
                                                         user = new TwitterUser() {screen_name = AggressorName}
                                                     }
                                           },
                                           message =>
                                           {
                                               WasMessageSent = true;
                                               MessageSent = message;
                                               return message;
                                           }));
            _Arena = ObjectFactory.GetInstance<TweetArena>();

        }

        private bool WasMessageSent;
        private string MessageSent;
    }

    public abstract class duel_start_with_one_message_waiting_context
    {
        protected TweetArena _Arena;
        protected string VictimName = "@trvrtzn";
        protected string AggressorName = "@darkxanthos";
        protected string TwitterTag = "#ContestOfTwit";

        [TestFixtureSetUp]
        public void Setup()
        {
            ContainerBootstrapper.BootstrapStructureMap();

            Context();
            Because();

        }

        protected abstract void Because();

        protected abstract void Context();
    }
}
