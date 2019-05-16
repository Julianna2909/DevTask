using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public sealed class GameConfig: ScriptableObject
{
    [SerializeField] private List<Color> colors;
    [SerializeField] private float spawnRate;

    public List<Color> Colors => colors;
    public float SpawnRate => spawnRate;
}
