using System;

namespace SC.ServerInteraction
{
    public interface IServerConnector
    {
        void SendRequest(string method, Action<string> onComplete);
    }
}