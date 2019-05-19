   
       using UnityEngine;

public sealed class NegativeBubbleView : BubbleView
    {
        protected override void OnMouseUpAsButton()
        {
            GameManager.Instance.AddScore(-points);
            Hide();
        }
        
        public override void Init(Color color, int points) => base.Init(Color.red, points);
    }
