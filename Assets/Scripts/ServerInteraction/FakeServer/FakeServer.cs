using UnityEngine;

namespace SC.ServerInteraction.Fake
{
    public class FakeServer
    {
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
            string dataName = PlayerPrefs.GetString("LastShownData", "data7") == "data10" ? "data7" : "data10";
            PlayerPrefs.SetString("LastShownData", dataName);

            TextAsset jsonData = Resources.Load<TextAsset>($"ServerData/Leaderboard/{dataName}");
            return jsonData.text;
        }
    }
}