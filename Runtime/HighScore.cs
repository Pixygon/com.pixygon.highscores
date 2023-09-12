using System;
using UnityEngine;

namespace Pixygon.Highscores {
    [Serializable]
    public class HighScore {
        public string gameId;
        public string userId;
        public string userName;
        public int score;
        public int kills;
        public int time;
        public string detail;
        public string version;
        public int multiplierPercent;

        public HighScore(string gameId, string userId, string userName, int score, int kills, float time, string detail, string version, int multiplierPercent) {
            this.gameId = gameId;
            this.userId = userId;
            this.userName = userName;
            this.score = score;
            this.kills = kills;
            this.time = Mathf.FloorToInt(time);
            this.detail = detail;
            this.version = version;
            this.multiplierPercent = multiplierPercent;
        }
    }
}