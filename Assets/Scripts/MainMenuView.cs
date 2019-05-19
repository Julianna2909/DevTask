using UnityEngine;
using UnityEngine.UI;

public sealed class MainMenuView : BaseMenuView
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    public override void Init()
    {
        base.Init();
        startButton.onClick.AddListener(() => GameManager.Instance.Start());
        exitButton.onClick.AddListener(Application.Quit);
    }
}