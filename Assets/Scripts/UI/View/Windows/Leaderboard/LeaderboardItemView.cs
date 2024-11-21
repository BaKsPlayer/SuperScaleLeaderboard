using TMPro;
using UnityEngine;
using UnityEngine.UI;
using SC.Utils;

namespace SC.UI.View.Leaderboard
{
    public class LeaderboardItemView : MonoBehaviour
    {
        [SerializeField] private GameObject _defaultBackground;
        [SerializeField] private GameObject _playerBackground;

        [SerializeField] private Image _rankBadge;
        [SerializeField] private TextMeshProUGUI _rankLabel;
        [SerializeField] private Image _avatarBackground;
        [SerializeField] private Image _avatar;
        [SerializeField] private Image _flag;
        [SerializeField] private TextMeshProUGUI _nameLabel;

        [SerializeField] private TextMeshProUGUI _pointsLabel;
        [SerializeField] private GameObject _vipIcon;

        public void Init(ILeaderboardItemViewModel model)
        {
            _defaultBackground.SetActive(!model.IsPlayer);
            _playerBackground.SetActive(model.IsPlayer);

            _rankBadge.gameObject.SetActive(model.RankBadgeSprite != null);
            _rankBadge.sprite = model.RankBadgeSprite;
            _rankLabel.text = model.Rank.ToString();

            _avatarBackground.color = model.AvatarBackgroundColor;
            _avatar.sprite = model.AvatarSprite;

            _flag.sprite = model.FlagSprite;
            _nameLabel.text = model.PlayerName;

            _pointsLabel.text = model.PointsCount.ToString(withWhiteSpace: true);
            _vipIcon.SetActive(model.IsVip);
        }
    }
}