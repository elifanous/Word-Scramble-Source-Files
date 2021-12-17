using UnityEngine;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
    public GameManager gameManager;
    public Submit submit;
    public Timer timer;
    public GameObject gameOver, lightbulb;
    public InputField inputBox;
    
    void Start() {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) {
            TaskOnClick();
        }
    }

    void TaskOnClick() {
        timer.timerIsRunning = true;
        timer.timeRemaining = 15;
        if (gameManager.lives <= 0) {
            lightbulb.SetActive(false);
            gameOver.SetActive(true);
            Invoke("LoadScene", 1f);
        } else {
            gameManager.Load();
            inputBox.Select();
        }
    }

    void LoadScene() {
        gameManager.Load();
    }
}
