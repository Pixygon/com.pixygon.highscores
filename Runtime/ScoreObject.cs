using UnityEngine;
using TMPro;

namespace Pixygon.Highscores {
    public class ScoreObject : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _rank;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private TextMeshProUGUI _player;

        public void Set(int pos, HighScore score, string s) {
            _rank.text = $"{pos}";
            _score.text = s switch {
                "score" => $"{score.score}",
                "kills" => $"{score.kills}",
                "time" => $"{score.time}",
            };
            _player.text = $"{score.userName}";
        }
    }
}