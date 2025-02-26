using System;
using UnityEngine;

namespace SC.ServerInteraction.Fake
{
    public class FakeServerConnector : IServerConnector
    {
        private readonly FakeServer _server;

        public FakeServerConnector(FakeServer fakeServer)
        {
            _server = fakeServer;
        }

        public void SendRequest(string method, Action<string> onComplete)
        {
            onComplete.Invoke(_server.HandleRequest(method));
        }

        public void KillRequest(string method)
        {
            Debug.Log($"Request to {method} was killed");
        }
    }
}