using UnityEngine;
using UnityEngine.UI;

public class ResizeGameObject : MonoBehaviour
{
    public Text textComponent; // Перетащите сюда компонент Text из объекта

    private void Update()
    {
        ResizeObject();
    }

    private void ResizeObject()
    {
        if (textComponent != null)
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, textComponent.preferredHeight+20);
        }
    }
}
