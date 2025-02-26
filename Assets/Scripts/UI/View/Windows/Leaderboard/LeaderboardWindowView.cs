using UnityEngine;
using UnityEngine.UI;

namespace SC.UI.View.Leaderboard
{
    public class LeaderboardWindowView : BaseWindow
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private LeaderboardItemView _itemViewPrefab;
        [SerializeField] private float _maxScrollRectHeight;

        private ILeaderboardWindowViewModel _model;
        
        public void Init(ILeaderboardWindowViewModel model)
        {
            _model = model;

            _model.ItemModels.CollectionChanged += RefreshContent;
            RefreshContent();
        }

        private void RefreshContent()
        {
            ClearContent();
            
            if (_model.ItemModels == null || _model.ItemModels.Count == 0)
            {
                return;
            }
            
            foreach (var itemModel in _model.ItemModels)
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

            _scrollRect.vertical = rectTransform.sizeDelta.y < _scrollRect.content.sizeDelta.y;
        }

        private void OnDestroy()
        {
            _model.ItemModels.CollectionChanged -= RefreshContent;
            _model.Dispose();
        }
    }
}