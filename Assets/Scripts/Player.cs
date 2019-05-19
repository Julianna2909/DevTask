    using UnityEngine;

public sealed class Player
    {
        private int score;

        public void AddScore(int points) => score += points;

        public int GetScore() => score;

        public void ResetScore() => score = 0;
    }
