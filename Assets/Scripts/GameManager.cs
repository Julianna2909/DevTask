
using UnityEngine;

public sealed class   GameManager
{
    private readonly Spawner spawner;
    private readonly GameConfig gameConfig;
    private readonly Player player;

    private static GameManager instance;

    public static GameManager Instance => instance;

    public GameConfig GameConfig => gameConfig;

    public GameManager(Spawner spawner, GameConfig gameConfig, Player player)
    {
        this.spawner = spawner;
        this.gameConfig = gameConfig;
        this.player = player;

        instance = this;
    }

    public void Start()
    {
        spawner.StartSpawning();
    }

    public Color GetRandomColor()
    {
        int maxIndex = gameConfig.Colors.Count;
        int randomIndex = Random.Range(0, maxIndex);
        return gameConfig.Colors[randomIndex];
    }

    public void AddScore(int points) => player.AddScore(points);
}
