using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTextCharacterByCharacter : MonoBehaviour
{
    public Text textElement; // Ссылка на компонент Text, в который будем выводить текст
    public string displayText = "Пример текста"; // Ваша строка для отображения
    public float characterDelay = 0.1f; // Задержка между символами

    private int currentIndex = 0;

    private void Start()
    {
        StartCoroutine(DisplayText());
    }

    private IEnumerator DisplayText()
    {
        while (currentIndex < displayText.Length)
        {
            textElement.text += displayText[currentIndex];
            currentIndex++;
            yield return new WaitForSeconds(characterDelay);
        }
    }
}
