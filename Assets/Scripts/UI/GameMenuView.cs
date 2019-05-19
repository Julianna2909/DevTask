using Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class GameMenuView : BaseMenuView
    {
        [SerializeField] private Button pauseButton;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text timeText;

        public override void Init()
        {
            base.Init();
            pauseButton.onClick.AddListener(() => GameManager.Instance.Pause());
        }

        public void ShowScore(int score)
        {
            scoreText.text = score.ToString();
        }

        public void ShowTime(int second)
        {
            timeText.text = second.ToString();
        }
    }
}