using System;
using System.Collections.Generic;
using Pixygon.Passport;
using TMPro;
using UnityEngine;

namespace Pixygon.Highscores {
    public class HighscoreTable : MonoBehaviour {
        [SerializeField] private ScoreObject _highscoreObjectPrefab;
        [SerializeField] private Transform _highscoreParent;
        [SerializeField] private TextMeshProUGUI _scoreTypeText;

        private List<ScoreObject> _scores;
        private string _searchType = "score";
        public string Version { get; set; }
        public string Game { get; set; }

        public string FromDate { get; set; } = "2023-09-10";
        public string ToDate { get; set; } = "2023-09-12";

        private void Awake() {
            _scoreTypeText.text = _searchType;
        }
        public async void GetHighscores() {
            PopulateBoard(JsonUtility.FromJson<Highscores>(await PixygonApi.GetHighScores(
                Game, _searchType, Version, FromDate, ToDate)));
        }

        public static void PostHighscore(string game, string user, int score, int kills, float time, string detail, string version = "1.0.0", int multiplierPercent = 100) {
            PixygonApi.PostHighScore(JsonUtility.ToJson(new HighScore(game, user, "", score, kills, time, detail, version, multiplierPercent)));
        }

        public void SetSearchType(int i) {
            _searchType = i switch {
                0 => "score",
                1 => "kills",
                2 => "time"
            };
            _scoreTypeText.text = _searchType;
            GetHighscores();
        }

        private void ClearBoard() {
            if (_scores == null) return;
            foreach (var s in _scores) {
                Destroy(s.gameObject);
            }
            _scores = null;
        }

        private void PopulateBoard(Highscores scores) {
            ClearBoard();
            if (scores == null) return;
            _scores = new List<ScoreObject>();
            for (var i = 0; i < scores.highscores.Length; i++) {
                var g = Instantiate(_highscoreObjectPrefab, _highscoreParent);
                g.Set(i + 1, scores.highscores[i], _searchType);
                _scores.Add(g);
            }

            _highscoreParent.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, _scores.Count * 30f);
        }
    }
}