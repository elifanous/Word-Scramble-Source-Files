using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryAgain : MonoBehaviour
{
    public GameManager gameManager;
    public Submit submit;
    public Timer timer;
    public GameObject gameOver, lightbulb;
    
    void Start() {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick() {
        submit.score = 0;
        submit.lives = 3;
        submit.UpdateScore();
        submit.UpdateLives();
        gameOver.SetActive(false);
        lightbulb.SetActive(true);
        timer.timeRemaining = 15;
    }
}
