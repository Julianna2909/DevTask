
using UnityEngine;

public sealed class GameManager
{
    private readonly Spawner spawner;
    private readonly GameConfig gameConfig;

    private static GameManager instance;

    public static GameManager Instance => instance;

    public GameConfig GameConfig => gameConfig;

    public GameManager(Spawner spawner, GameConfig gameGameConfig)
    {
        this.spawner = spawner;
        this.gameConfig = gameGameConfig;

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
}
