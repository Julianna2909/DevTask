using Bubbles;
using Configs;
using UI;
using UnityEngine;

namespace Game
{
    public sealed class GameInitializer : MonoBehaviour
    {
        [SerializeField] private Spawner spawner;
        [SerializeField] private GameConfig gameConfig;
        [SerializeField] private Timer timer;
        [SerializeField] private MainMenuView mainMenuView;
        [SerializeField] private GameMenuView gameMenuView;
        [SerializeField] private PauseMenuView pauseMenuView;
        [SerializeField] private EndGameMenuView endGameMenuView;
        [SerializeField] private GameObject blocker;

        private Player player;

        private void InitServer()
        {
            var server = new Server();
            server.UserDataLoaded += OnUserDataLoaded;
            server.Init();
        }

        private void OnUserDataLoaded(bool success)
        {
            Server.Instance.UserDataLoaded -= OnUserDataLoaded;
            if (success)
            {
                player = new Player();
                GameManager gameManager = new GameManager(spawner, gameConfig, player, timer, mainMenuView,
                    gameMenuView, pauseMenuView, endGameMenuView, blocker);
            }
            else InitServer();
        }

        void Awake()
        {
            InitServer();
        }
    }
}