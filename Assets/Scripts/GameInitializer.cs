using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private GameConfig gameConfig;

    void Awake()
    {
        GameManager gameManager = new GameManager(spawner, gameConfig);
        gameManager.Start();
    }
}

