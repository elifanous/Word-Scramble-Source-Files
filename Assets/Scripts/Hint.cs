using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    public Timer timer;
    public GameObject hintPanel;
    private Animator animator;
    bool HintPanelVisible = false;
    
    void Start() {
        animator = hintPanel.GetComponent<Animator>();
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick() {
        Debug.Log("Clicked!");
        timer.timerIsRunning = false;
        gameObject.GetComponent<Animator>().Play("HintBtnFadeOut");
        hintPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
