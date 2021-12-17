using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Submit submit;
    public Text timer;
    public float timeRemaining;
    public bool timerIsRunning = true;
    string timerText;

    void Update() {
        if (timerIsRunning) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
            } else {
                timeRemaining = 0;
                timerIsRunning = false;
                submit.Override = true;
                submit.TaskOnClick();
            }
        }
        timer.text = timeRemaining.ToString("0");
    }
}
