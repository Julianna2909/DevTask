using UnityEngine;

public class BubbleView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float currentPrice;
    private float price;
    private bool isShowing;
    private float deltaPrice;

    public void Init(Color color)
    {
        spriteRenderer.color = color;
        currentPrice = 10f;

        Show();
    }

    public void Show()
    {
        isShowing = true;
    }

    private void Update()
    {
        if (!isShowing) return;

        currentPrice -= deltaPrice;

       // TODO: if tupped - Hide();
    }

    public void Hide()
    {
        Destroy(gameObject);
    }
}
