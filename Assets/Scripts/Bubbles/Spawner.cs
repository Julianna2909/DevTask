using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

namespace Bubbles
{
    public sealed class Spawner : MonoBehaviour
    {
        [SerializeField] private BubbleView bubbleViewPrefab;
        [SerializeField] private NegativeBubbleView negativeBubbleViewPrefab;
        [SerializeField] private Transform bubblesParent;

        private List<BubbleView> views;

        private Vector2 bubbleRange;

        private float time;
        private float rate;

        private float randomizeBubbles;

        public void StartSpawning()
        {
            ClearViews();
            bubbleRange = GameManager.Instance.GameConfig.BubbleRange;

            rate = GameManager.Instance.GameConfig.SpawnRate;
            time = rate;
            StartCoroutine(Spawn());
        }

        public void StopSpawning() => StopAllCoroutines();

        public void ClearViews()
        {
            StopSpawning();
            views?.ForEach(v => { if (v != null) v.Hide(); });
            views?.Clear();
            views = new List<BubbleView>();
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                time += Time.deltaTime;
                if (time > rate)
                {
                    randomizeBubbles = Random.Range(0f, 1f);
                    BubbleView bubbleToSpawn;
                    if (randomizeBubbles < 0.5f) bubbleToSpawn = bubbleViewPrefab;
                    else bubbleToSpawn = negativeBubbleViewPrefab;
                    views.Add(SpawnBubble(bubbleToSpawn));

                    time = 0;
                }

                yield return null;
            }
        }

        private BubbleView SpawnBubble(BubbleView bubbleView)
        {
            BubbleView bubble = Instantiate(bubbleView, bubblesParent);
            bubble.Init(GameManager.Instance.GetRandomColor(), GameManager.Instance.GameConfig.BubblePoints);
            bubble.transform.localPosition = new Vector2(Random.Range(-bubbleRange.x, bubbleRange.x),
                Random.Range(-bubbleRange.y, bubbleRange.y));
            return bubble;
        }
    }
}