using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextSwitcher : MonoBehaviour
{
    public Text textElement;
    public string[] texts;
    public int currentIndex = 0;

    private void Start()
    {
        UpdateText();
    }

    public void NextText()
    {   
        currentIndex = Mathf.Clamp(currentIndex + 1, 0, texts.Length);
        if(currentIndex<texts.Length)
            UpdateText();
        else SceneManager.LoadScene("SecondScene");

        
    }

    /*public void PreviousText()
    {
        currentIndex = Mathf.Clamp(currentIndex - 1, 0, texts.Length-1);
        UpdateText();
    }*/

    private void UpdateText()
    {
        textElement.text = texts[currentIndex];
    }
}
