using System;
using Zenject;

namespace SC.ServerInteraction.Fake
{
    public class FakeServerConnector : IServerConnector
    {
        private FakeServer _server;

        [Inject]
        public FakeServerConnector(FakeServer fakeServer)
        {
            _server = fakeServer;
        }

        public void SendRequest(string method, Action<string> onComplete)
        {
            onComplete.Invoke(_server.HandleRequest(method));
        }
    }
}