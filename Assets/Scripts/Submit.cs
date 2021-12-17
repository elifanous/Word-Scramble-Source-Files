using UnityEngine;
using UnityEngine.UI;

public class Submit : MonoBehaviour {
    public GameManager gameManager;
    public Timer timer;
    public InputField Input;
    public Button AnswerBtn, HintBtn, ShuffleBtn;
    public Text Score, FinalScore;
    public GameObject CorrectTxt, IncorrectTxt, ContinueBtn;
    public Image Heart3, Heart2, Heart1, Heart0;
    private Animator animator;
    public bool Override = false;
    public int score;
    public int lives;

    void Start() {
        score = gameManager.score;
        lives = gameManager.lives;
        animator = Input.GetComponent<Animator>();
        Button btn = AnswerBtn.GetComponent<Button>();
        InputField inputBox = Input.GetComponent<InputField>();
        btn.onClick.AddListener(TaskOnClick);
        Input.onEndEdit.AddListener(delegate{TaskOnClick();});
    }

    public void TaskOnClick() {
        string randomWord = gameManager.randomWord;
        string inp = Input.text.ToLower();
        if (inp.Length > 0 || Override == true) {
            Override = false;
            timer.timerIsRunning = false;
            if (inp == randomWord) {
                CorrectAnswer();
            } else {
                WrongAnswer();
            }
        }
    }

    void CorrectAnswer() {
        Debug.Log("Correct!");
        score += 1;
        UpdateScore();
        AnswerSubmission();
        Input.GetComponent<Image>().color = new Color(52/255f, 241/255f, 69/255f, 1f);
        animator.Play("AnswerBoxCorrect");
        animator.SetTrigger("Reset");
        CorrectTxt.SetActive(true);
        Invoke("ShowContinueBtn", 1.5f);
    }

    void WrongAnswer() {
        Debug.Log("False");
        lives -= 1;
        UpdateLives();
        AnswerSubmission();
        Input.GetComponent<Image>().color = new Color(1f,87/255f,87/255f,1f);
        animator.Play("AnswerBoxShake");
        animator.SetTrigger("Reset");
        IncorrectTxt.SetActive(true);
        Invoke("ShowContinueBtn", 2f);
    }

    void AnswerSubmission() {
        Input.interactable = false;
        AnswerBtn.interactable = false;
        HintBtn.interactable = false;
        ShuffleBtn.interactable = false;
    }

    void ShowContinueBtn() {
        GetComponent<Animator>().Play("AnswerBtnFade");
        GetComponent<Animator>().SetTrigger("Rest");
        ContinueBtn.SetActive(true);
    }

    public void UpdateScore() {
        string t_score = "Score: " + score.ToString();
        Score.text = FinalScore.text = t_score;
    }

    public void UpdateLives() {
        if (lives == 3) {
            Heart3.enabled = true;
            Heart2.enabled = Heart1.enabled = Heart0.enabled = false;
        } else if (lives == 2) {
            Heart2.enabled = true;
            Heart3.enabled = Heart1.enabled = Heart0.enabled = false;
        } else if (lives == 1) {
            Heart1.enabled = true;
            Heart3.enabled = Heart2.enabled = Heart0.enabled = false;
        } else if (lives <= 0) {
            Heart0.enabled = true;
            Heart3.enabled = Heart2.enabled = Heart1.enabled = false;
        } else {
            Debug.Log("Life number error.");
        }
    }
}