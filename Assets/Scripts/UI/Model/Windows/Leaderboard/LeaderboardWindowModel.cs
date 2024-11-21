using System.Collections.Generic;
using System.Linq;
using SC.UI.View.Leaderboard;

namespace SC.UI.Model.Windows.Leaderboard
{
    public class LeaderboardWindowModel : ILeaderboardWindowViewModel
    {
        public List<ILeaderboardItemViewModel> ItemModels { get; }

        public LeaderboardWindowModel(List<ILeaderboardItemViewModel> leaderboardItems)
        {
            ItemModels = leaderboardItems.OrderBy(item => item.Rank).ToList();
        }
    }
}