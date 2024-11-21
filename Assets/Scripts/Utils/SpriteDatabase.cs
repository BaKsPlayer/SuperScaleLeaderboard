using System.Collections.Generic;
using UnityEngine;

namespace SC.Utils
{
    [CreateAssetMenu(fileName = "SpriteDatabase", menuName = "Database/SpriteDatabase")]
    public class SpriteDatabase : ScriptableObject
    {
        [SerializeField] private List<SpriteEntry> _characterAvatars = new List<SpriteEntry>();
        [SerializeField] private List<CountryFlagEntry> _countryFlags = new List<CountryFlagEntry>();
        [SerializeField] private List<SpriteEntry> _rankBadges = new List<SpriteEntry>();

        public Sprite GetCharacterAvatar(int id)
        {
            var characterAvatar = _characterAvatars.Find(entry => entry.id == id)?.sprite;

            if (characterAvatar == null)
            {
                Debug.LogError($"Character avatar with id {id} not found in the database.");
            }

            return characterAvatar;
        }

        public Sprite GetCountryFlag(string countryCode)
        {
            var flagSprite = _countryFlags.Find(entry => entry.countryCode == countryCode)?.sprite;

            if (flagSprite == null)
            {
                Debug.LogError($"Flag of {countryCode} not found in the database.");
            }

            return flagSprite;
        }

        public Sprite GetRankBadge(int id)
        {
            var rankBadge = _rankBadges.Find(entry => entry.id == id)?.sprite; ;

            if (rankBadge == null)
            {
                Debug.LogError($"Rank badge with id {id} not found in the database.");
            }

            return rankBadge;
        }

        [System.Serializable]
        private class SpriteEntry
        {
            public int id;
            public Sprite sprite;
        }

        [System.Serializable]
        private class CountryFlagEntry
        {
            public string countryCode;
            public Sprite sprite;
        }
    }
}