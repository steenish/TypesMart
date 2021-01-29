using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour {

	private int currentIndex = 0;

	private string _itemName;
	public string itemName {
		get {
			return _itemName;
		}
		set {
			text.text = value;
			_itemName = value;
		}
	}
	private TMP_Text text;

	private static Color grayColor = new Color(0.5f, 0.5f, 0.5f);

	void Awake() {
		text = transform.Find("Canvas/Background/Text").GetComponent<TMP_Text>();
	}

	public bool SendCharacter(char character) {
		if (itemName[currentIndex] == character) {
			currentIndex++;
			SetText();
		}

		// Return whether the final character has been entered.
		return currentIndex == itemName.Length;
	}

	private void SetText() {
		for (int i = 0; i < currentIndex; ++i) {
			int meshIndex = text.textInfo.characterInfo[i].materialReferenceIndex;
			int vertexIndex = text.textInfo.characterInfo[i].vertexIndex;

			Color32[] vertexColors = text.textInfo.meshInfo[meshIndex].colors32;
			vertexColors[vertexIndex + 0] = grayColor;
			vertexColors[vertexIndex + 1] = grayColor;
			vertexColors[vertexIndex + 2] = grayColor;
			vertexColors[vertexIndex + 3] = grayColor;
		}

		text.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
	}
}
