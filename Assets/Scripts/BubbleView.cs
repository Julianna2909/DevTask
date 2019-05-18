using UnityEngine;

public class BubbleView : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spriteRenderer;

    protected int points;
    protected bool isShowing;

    protected internal virtual void Init(Color color)
    {
        points = GameManager.Instance.GameConfig.BubblePoints;
        spriteRenderer.color = color;
        Show();
    }

    public void Show() => isShowing = true;

    public void Hide() => Destroy(gameObject);

    protected virtual void OnMouseUpAsButton()
    {
        GameManager.Instance.AddScore(points);
        Hide();
    }
}
