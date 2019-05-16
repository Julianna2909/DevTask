using System.Collections;
using UnityEngine;

    public class Spawner : MonoBehaviour
    {
        [SerializeField] private BubbleView bubbleView;
        [SerializeField] private Transform bubblesParent;
        [SerializeField] private float maxX;
        [SerializeField] private float maxY;
        [SerializeField] private float minX;
        [SerializeField] private float minY;

        private float time;
        private float rate;

        public void StartSpawning()
        {
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
                if (time > rate)
                {
                    BubbleView obs = Instantiate(bubbleView, bubblesParent);
                    obs.Init(GameManager.Instance.GetRandomColor());
                    obs.transform.localPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

                    time = 0;
                }
                yield return null;
            }
        }
    } 
