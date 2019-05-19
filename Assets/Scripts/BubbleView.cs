using UnityEngine;

public class BubbleView : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spriteRenderer;

    protected int points;
    protected bool isShowing;

    public virtual void Init(Color color, int points)
    {
        this.points = points;
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
