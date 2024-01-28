using Pixygon.Passport;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Pixygon.Highscores {
    public class ScoreObject : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _rank;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private TextMeshProUGUI _player;
        [SerializeField] private TextMeshProUGUI _version;
        [SerializeField] private Image _avatarImage;

        private string _userId;
        public void Set(int pos, HighScore score, string s) {
            _rank.text = $"{pos}";
            _score.text = s switch {
                "score" => $"{score.score}",
                "kills" => $"{score.kills}",
                "time" => $"{score.time}",
            };
            _player.text = $"{score.userName}";
            _version.text = $"v{score.version}";
            _avatarImage.sprite = null; // score.userId
            _userId = score.userId;
        }

        public void OnClick() {
            FindFirstObjectByType<PassportCard>().GetUser(_userId);
        }
    }
}