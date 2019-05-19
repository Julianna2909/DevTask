using UnityEngine;

namespace UI
{
    public abstract class BaseMenuView : MonoBehaviour
    {
        public virtual void Init()
        {
            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}