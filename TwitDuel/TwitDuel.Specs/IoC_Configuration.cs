using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using TwitDuel.Core;

namespace TwitDuel.Specs
{
    public static class ContainerBootstrapper
    {
        public static void BootstrapStructureMap()
        {
            // Initialize the static ObjectFactory container
            ObjectFactory.Initialize(x =>
                                         {
                                             x.ForRequestedType<ITweetRepository>().TheDefaultIsConcreteType<TweetRepository>();
                                             x.ForRequestedType<ITweetInterpreter>().TheDefaultIsConcreteType<TweetInterpreter>();
                                             x.ForRequestedType<IDuelInterpreter>().TheDefaultIsConcreteType<DuelInterpreter>();
                                             x.ForRequestedType<ITwitterDataAccess>().TheDefaultIsConcreteType<FakeDataAccess>();
                                         }
                );
        }
    }
}