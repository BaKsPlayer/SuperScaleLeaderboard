using UnityEngine;

namespace SC.ServerInteraction.Fake
{
    public class FakeServer
    {
        private const string LEADERBOARD_DATA_FOLDER_PATH = "ServerData/Leaderboard";
        private int _currentLeaderboardIndex = 0;
        
        public string HandleRequest(string method)
        {
            if (method == "GetLeaderboardData")
            {
                return GetLeaderboardData();
            }

            return "{\"error\":\"Invalid method name\"}";
        }
        
        private string GetLeaderboardData()
        {
            TextAsset[] allData = Resources.LoadAll<TextAsset>(LEADERBOARD_DATA_FOLDER_PATH);
            if (allData.Length == 0)
            {
                Debug.LogError("No leaderboard data found!");
                return string.Empty;
            }

            _currentLeaderboardIndex = ++_currentLeaderboardIndex % allData.Length;
            return allData[_currentLeaderboardIndex].text;
        }
    }
}