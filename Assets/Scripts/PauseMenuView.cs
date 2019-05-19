using UnityEngine;
using UnityEngine.UI;

public sealed class PauseMenuView : BaseMenuView
{
    [SerializeField] private Button unpauseButton;
    [SerializeField] private Button exitButton;

    public override void Init()
    {
        base.Init();
        unpauseButton.onClick.AddListener(() => GameManager.Instance.Unpause());
        exitButton.onClick.AddListener(Application.Quit);
    }
}