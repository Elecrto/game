using UnityEngine;
using UnityEngine.UI;

public class AutoSizeText : MonoBehaviour
{
    public Text textComponent; // Перетащите сюда компонент Text из объекта

    private void Update()
    {
        if (textComponent != null)
        {
            // Измените размер RectTransform в зависимости от предпочтительной высоты текста
            RectTransform rectTransform = textComponent.rectTransform;
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, textComponent.preferredHeight);
        }
    }
}
