using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public sealed class GameConfig: ScriptableObject
{
    [SerializeField] private List<Color> colors;
    [SerializeField] private float spawnRate;
    
    [SerializeField] private float bublleRangeX;
    [SerializeField] private float bublleRangeY;

    [SerializeField] private int bubblePoints;

    public List<Color> Colors => colors;
    public float SpawnRate => spawnRate;

    public float BublleRangeX => bublleRangeX;
    public float BublleRangeY => bublleRangeY;

    public int BubblePoints => bubblePoints;
}
