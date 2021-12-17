using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StretchToFit : MonoBehaviour
{
    public Text HighScoreMain;

    void Update() {
        RectTransform boxRectTransform = gameObject.GetComponent<RectTransform>();
        RectTransform textRectTransform = HighScoreMain.GetComponent<RectTransform>();
        float originalHeight = boxRectTransform.rect.height;
        float newWidth = textRectTransform.rect.width + 30f;
        boxRectTransform.sizeDelta = new Vector2(newWidth, originalHeight);
    }
}
