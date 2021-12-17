using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rescramble : MonoBehaviour
{
    public GameManager gameManager;
    
    void Start() {
        Button ScrambleBtn = gameObject.GetComponent<Button>();
        ScrambleBtn.onClick.AddListener(ScrambleBtnClick);
    }

    void ScrambleBtnClick() {
        gameManager.setWord(gameManager.randomWord);
    }
}
