using Bubbles;
using Configs;
using UI;
using UnityEngine;

namespace Game
{
    public sealed class GameManager
    {
        private readonly Spawner spawner;
        private readonly GameConfig gameConfig;
        private readonly Player player;
        private readonly Timer timer;
        private readonly MainMenuView mainMenuView;
        private readonly GameMenuView gameMenuView;
        private readonly PauseMenuView pauseMenuView;
        private readonly EndGameMenuView endGameMenuView;
        private readonly GameObject blocker;

        private static GameManager instance;

        public static GameManager Instance => instance;

        public GameConfig GameConfig => gameConfig;

        public GameManager(Spawner spawner, GameConfig gameConfig, Player player, Timer timer,
            MainMenuView mainMenuView, GameMenuView gameMenuView, PauseMenuView pauseMenuView,
            EndGameMenuView endGameMenuView, GameObject blocker)
        {
            this.spawner = spawner;
            this.gameConfig = gameConfig;
            this.player = player;
            this.timer = timer;
            this.mainMenuView = mainMenuView;
            this.gameMenuView = gameMenuView;
            this.pauseMenuView = pauseMenuView;
            this.endGameMenuView = endGameMenuView;
            this.blocker = blocker;

            this.mainMenuView.Init();
            this.gameMenuView.Init();
            this.pauseMenuView.Init();
            this.endGameMenuView.Init();

            this.mainMenuView.Show();

            instance = this;
        }

        public void Start()
        {
            mainMenuView.Hide();
            gameMenuView.Show();
            ResetScore();
            timer.StartTimer(gameConfig.GameDuration, () =>
                {
                    blocker.SetActive(true);
                    spawner.StopSpawning();
                    endGameMenuView.Show();
                },
                second => gameMenuView.ShowTime(gameConfig.GameDuration - second));
        
            blocker.SetActive(false);
            spawner.StartSpawning();
        }

        public Color GetRandomColor()
        {
            int maxIndex = gameConfig.Colors.Count;
            int randomIndex = Random.Range(0, maxIndex);
            return gameConfig.Colors[randomIndex];
        }

        public void Pause()
        {
            blocker.SetActive(true);
            pauseMenuView.Show();
            Time.timeScale = 0;
        }

        public void Unpause()
        {
            Time.timeScale = 1;
            pauseMenuView.Hide();
            blocker.SetActive(false);
        }

        public void Restart()
        {
            endGameMenuView.Hide();
            Start();
        }

        public void AddScore(int points)
        {
            player.AddScore(points);
            gameMenuView.ShowScore(player.GetScore());
        }

        public void ResetScore()
        {
            player.ResetScore();
            gameMenuView.ShowScore(player.GetScore());
        }
    }
}
