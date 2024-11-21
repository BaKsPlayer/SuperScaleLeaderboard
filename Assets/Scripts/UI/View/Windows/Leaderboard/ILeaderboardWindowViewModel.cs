using System.Collections.Generic;

namespace SC.UI.View.Leaderboard
{
    public interface ILeaderboardWindowViewModel
    {
        List<ILeaderboardItemViewModel> ItemModels { get; }
    }
}