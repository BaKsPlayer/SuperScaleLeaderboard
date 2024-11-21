using UnityEngine;
using UnityEngine.UI;

namespace SC.UI.View.Leaderboard
{
    public class LeaderboardWindowView : BaseWindow
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private LeaderboardItemView _itemViewPrefab;
        [SerializeField] private float _maxScrollRectHeight;
        [SerializeField] private Button _closeButton;

        private void Awake()
        {
            _closeButton.onClick.AddListener(Close);
        }

        public void Init(ILeaderboardWindowViewModel model)
        {
            ClearContent();

            foreach (var itemModel in model.ItemModels)
            {
                var itemView = Instantiate(_itemViewPrefab, _scrollRect.content);
                itemView.Init(itemModel);
            }

            SetScrollRect();
        }

        private void ClearContent()
        {
            foreach (Transform t in _scrollRect.content)
            {
                Destroy(t);
            }
        }

        private void SetScrollRect()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(_scrollRect.content);

            var rectTransform = _scrollRect.GetComponent<RectTransform>();
            var height = Mathf.Clamp(_scrollRect.content.sizeDelta.y, 0, _maxScrollRectHeight);
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);

            _scrollRect.vertical = _scrollRect.GetComponent<RectTransform>().sizeDelta.y < _scrollRect.content.sizeDelta.y;
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveAllListeners();
        }
    }
}