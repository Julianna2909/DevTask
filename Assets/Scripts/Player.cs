    using UnityEngine;

public sealed class Player
    {
        private int score;

        public void AddScore(int points)
        {
            score += points;
            Debug.Log(score);
        }
    }
