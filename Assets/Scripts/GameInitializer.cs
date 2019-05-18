using UnityEngine;

public sealed class GameInitializer : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private GameConfig gameConfig;
    
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
            GameManager gameManager = new GameManager(spawner, gameConfig, player);
            gameManager.Start();
        }
        else InitServer();
    }

    void Awake()
    {
        InitServer();
    }
}

