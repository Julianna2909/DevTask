using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu]
    public sealed class GameConfig : ScriptableObject
    {
        [SerializeField] private List<Color> colors;
        [SerializeField] private int gameDuration;
        [SerializeField] private float spawnRate;

        [SerializeField] private Vector2 bubbleRange;

        [SerializeField] private int bubblePoints;

        public List<Color> Colors => colors;
        public int GameDuration => gameDuration;
        public float SpawnRate => spawnRate;

        public Vector2 BubbleRange => bubbleRange;

        public int BubblePoints => bubblePoints;
    }
}