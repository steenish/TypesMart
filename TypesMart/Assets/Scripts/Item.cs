using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class Item : MonoBehaviour {
   
    private int currentIndex = 0;
    private string itemName = "sample_im";
    private TMP_Text backText;
    private TMP_Text frontText;

    void Start() {
        //RectTransform background = transform.Find("Background").GetComponent<RectTransform>();
        //background.sizeDelta = new Vector2(characterWidth * itemName.Length + 2 * margin, height);

        //backText = transform.Find("Background/BackText").GetComponent<TMP_Text>();
        frontText = transform.Find("Background/FrontText").GetComponent<TMP_Text>();

        //backText.text = itemName;
        frontText.text = itemName;

        //frontText.GetComponent<RectTransform>().sizeDelta = frontText.GetTextBounds();//new Vector2(characterWidth * itemName.Length, height * 0.5f);
    }

    public bool SendCharacter(char character) {
        if (itemName[currentIndex] == character) {
            currentIndex++;
            SetFrontText();

            return currentIndex == itemName.Length;
        }
        return false;
    }

    private void SetFrontText() {
        frontText.text = itemName.Substring(currentIndex);
    }
}
