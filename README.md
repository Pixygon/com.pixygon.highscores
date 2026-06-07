# Pixygon — HighScores

Online leaderboards for Pixygon games — submit runs to the backend and render filterable score tables in-game.

## Overview

This package handles the full highscore loop for Pixygon titles: posting a player's run (score, kills, time) to the Pixygon API and displaying ranked leaderboards in a Unity UI. It builds on `com.pixygon.passport` for player identity and backend access, sitting one layer above it as a gameplay-facing feature. Drop in the included prefabs to get a working board with version, date-range, and score-type filtering.

## Key types

| Type | What it is |
| --- | --- |
| `HighScore` | `[Serializable]` data record for one run — `gameId`, `userId`, `userName`, `score`, `kills`, `time`, `detail`, `version`, `multiplierPercent`. The unit you post and receive. |
| `Highscores` | `[Serializable]` wrapper holding a `HighScore[]`; the deserialization target for API responses. |
| `HighscoreTable` | `MonoBehaviour` leaderboard controller. Static `PostHighscore(...)` submits a run; instance methods fetch, filter, and populate the board. |
| `ScoreObject` | `MonoBehaviour` for a single row — renders rank, score, player, version, and applies podium colors/icons for the top three. |
| `DateSelecter` | `MonoBehaviour` day/month/year picker widget; raises `OnDateChange` to drive the table's date-range filter. |

## How games use it

1. **Submit a run** when gameplay ends — static, no scene setup needed:

   ```csharp
   HighscoreTable.PostHighscore(
       game: "my-game-id",
       user: passport.UserId,
       score: finalScore,
       kills: kills,
       time: elapsedSeconds,
       detail: "normal-mode",
       version: "1.2.0",
       multiplierPercent: 100);
   ```

2. **Display the board** by placing the `HighscoreTable` prefab in a Canvas and wiring its `_gameId`, `PassportCard`, and date selectors in the inspector.
3. Call `GetHighscores()` to fetch and render; use `SetSearchType(0|1|2)` to switch between score/kills/time and `OnNextVersion(±1)` to page through versions.

## Dependencies

- **com.pixygon.passport** (`0.5.0`) — supplies `PixygonApi` for the highscore GET/POST endpoints, `PassportCard` for player identity, and user lookup on row click.

## Install

```json
"com.pixygon.highscores": "https://github.com/Pixygon/com.pixygon.highscores.git"
```
