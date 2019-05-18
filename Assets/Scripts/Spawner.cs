using System.Collections;
using UnityEngine;

    public sealed class Spawner : MonoBehaviour
    {
        [SerializeField] private BubbleView bubbleView;
        [SerializeField] private NegativeBubbleView negativeBubbleView;
        [SerializeField] private Transform bubblesParent;
        
        private float bublleRangeX;
        private float bublleRangeY;

        private float time;
        private float rate;

        private float randomizeBubles;

        public void StartSpawning()
        {
            bublleRangeX = GameManager.Instance.GameConfig.BublleRangeX;
            bublleRangeY = GameManager.Instance.GameConfig.BublleRangeY;

            rate = GameManager.Instance.GameConfig.SpawnRate;
            time = rate;
            StartCoroutine("Spawn");
        }

        public void StopSpawning() => StopAllCoroutines();

        private IEnumerator Spawn()
        {
            while (true) 
            {
                time += Time.deltaTime;
                randomizeBubles = Random.Range(0f, 1f);
                if (time > rate)
                {
                    if (randomizeBubles < 0.5f) SpawnBubble(bubbleView);
                    else SpawnBubble(negativeBubbleView);

                    time = 0;
                }
                yield return null;
            }
        }

        private void SpawnBubble(BubbleView bubbleView)
        {
            BubbleView bub = Instantiate(bubbleView, bubblesParent);
            bub.Init(GameManager.Instance.GetRandomColor());
            bub.transform.localPosition = new Vector2(Random.Range(-bublleRangeX, bublleRangeX), Random.Range(-bublleRangeY, bublleRangeY));
        }
        
        private void SpawnBubble(NegativeBubbleView negativeBubbleView)
        {
            BubbleView bub = Instantiate(negativeBubbleView, bubblesParent);
            bub.Init(GameManager.Instance.GetRandomColor());
            bub.transform.localPosition = new Vector2(Random.Range(-bublleRangeX, bublleRangeX), Random.Range(-bublleRangeY, bublleRangeY));
        }
        
        
    } 
