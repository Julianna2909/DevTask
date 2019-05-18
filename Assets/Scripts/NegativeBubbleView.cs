   
       using UnityEngine;

public sealed class NegativeBubbleView : BubbleView
    {
        protected override void OnMouseUpAsButton()
        {
            GameManager.Instance.AddScore(-points);
            Hide();
        }
        
        protected internal override void Init(Color color)
        {
            points = GameManager.Instance.GameConfig.BubblePoints;
            spriteRenderer.color = Color.red;
            Show();
        }
    }
