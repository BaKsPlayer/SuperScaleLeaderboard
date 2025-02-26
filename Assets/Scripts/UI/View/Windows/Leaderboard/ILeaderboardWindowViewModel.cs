using System;
using SC.Utils;

namespace SC.UI.View.Leaderboard
{
    public interface ILeaderboardWindowViewModel : IDisposable
    {
        ReactiveCollection<ILeaderboardItemViewModel> ItemModels { get; }
    }
}