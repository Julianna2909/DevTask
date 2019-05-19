using Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class EndGameMenuView : BaseMenuView
    {
        [SerializeField] private Button replayButton;
        [SerializeField] private Button exitButton;

        public override void Init()
        {
            base.Init();
            replayButton.onClick.AddListener(() => GameManager.Instance.Restart());
            exitButton.onClick.AddListener(Application.Quit);
        }
    }
}