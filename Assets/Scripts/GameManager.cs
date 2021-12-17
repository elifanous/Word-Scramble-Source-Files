using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string difficulty {
        get { return PlayerPrefs.GetString("difficulty"); }
        set { PlayerPrefs.SetString("difficulty", value); }
    }
    public int highScore {
        get { return PlayerPrefs.GetInt(difficulty); }
        set { PlayerPrefs.SetInt(difficulty, value); }
    }
    public int easyHighScore {
        get { return PlayerPrefs.GetInt("easy"); }
        set { PlayerPrefs.SetInt("easy", value); }
    }
    public int mediumHighScore {
        get { return PlayerPrefs.GetInt("medium"); }
        set { PlayerPrefs.SetInt("medium", value); }
    }
    public int hardHighScore {
        get { return PlayerPrefs.GetInt("hard"); }
        set { PlayerPrefs.SetInt("hard", value); }
    }
    public Text RandomWord, HintContent, HighScoreMain, HighScore;
    public GameObject CorrectTxt, IncorrectTxt, CorrectAnsTxt, HintBtn, ContinueBtn;
    public InputField InputBox;
    public Button AnswerBtn, ShuffleBtn, HomeBtn;
    public string randomWord, scrambledWord;
    public int score = 0;
    public int lives = 3;
    int wordLengthMax;
    int wordLengthMin;
    
    void Start() {
        var m_Path = Application.streamingAssetsPath;
        Debug.Log("dataPath: " + m_Path);
        Debug.Log("current directory: " + System.IO.Directory.GetCurrentDirectory());
        Load();
    }

    void Update() {
        Submit submit = AnswerBtn.GetComponent<Submit>();
        score = submit.score;
        lives = submit.lives;
        SetHighScore();
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) {
            highScore = easyHighScore = mediumHighScore = hardHighScore = 0;
            Debug.Log("High score has been reset.");
        }
    }

    void SetHighScore() {
        if (!PlayerPrefs.HasKey(difficulty)) {
            highScore = 0;
        }
        if (score > highScore) {
            highScore = score;
        }
        HighScore.text = HighScoreMain.text = "High Score: " + highScore;
    }

    public void Load() {
        resetScene();
        DifficultyCheck();
        randomWord = GenerateWord();
        setWord(randomWord);
        InputBox.interactable = AnswerBtn.interactable = HintBtn.GetComponent<Button>().interactable = ShuffleBtn.interactable = true;
        InputBox.Select();
        HomeBtn.onClick.AddListener(HomeBtnClick);
    }

    void resetScene() {
        HintBtn.SetActive(true);
        CorrectTxt.SetActive(false);
        IncorrectTxt.SetActive(false);
        ContinueBtn.SetActive(false);
        InputBox.GetComponent<Image>().color = new Color(1f,1f,1f,1f);
        InputBox.text = "";
    }

    void HomeBtnClick() {
        SceneManager.LoadScene("MainMenu");
    }

    public void setWord(string randWord) {
        scrambledWord = scramble(randWord);
        RandomWord.text = scrambledWord;
        HintContent.text = string.Format("The word starts with the letter \"{0}\"", randomWord[0]);
        CorrectAnsTxt.GetComponent<Text>().text = string.Format("Correct Answer: <b>{0}</b>", randomWord);
    }

    string GenerateWord() {
        var wordList = new List<string>();
        foreach (string line in System.IO.File.ReadLines(@$"{Application.streamingAssetsPath}\Words\dictionary.txt")) {
            if (wordLengthMin < line.Length && line.Length <= wordLengthMax) {
                wordList.Add(line);
            }
        }
        float length = wordList.Count;
        float rawIndex = Mathf.Floor(Random.Range(0f, length));
        int index = (int) rawIndex;
        string randomWord = wordList[index];
        return randomWord;
    }

    void DifficultyCheck() {
        if (difficulty == "easy") {
            wordLengthMin = 2;
            wordLengthMax = 4;
        } else if (difficulty == "medium") {
            wordLengthMin = 4;
            wordLengthMax = 6;
        } else if (difficulty == "hard") {
            wordLengthMin = 6;
            wordLengthMax = 100;
        }
    }

    string scramble(string word) {
        string scrambled = "";
        bool go = true;
        while (go) {
            //Makes a list containing letters of original word
            List<char> letterList = new List<char>();   
            foreach (char letter in word) {
                letterList.Add(letter);
            }

            //Assembles new list containing letters in scrambled order
            List<char> scramLetterList = new List<char>();
            int length = letterList.Count;
            for (int i=0; i < length; i++) {
                char randLetter = randomChoice(letterList);
                letterList.Remove(randLetter);
                scramLetterList.Add(randLetter);
            }

            //Complies aforementioned list into a string, effectively creating the word
            scrambled = "";
            foreach (char letter in scramLetterList) {
                scrambled += letter;
            }

            //Checks if scrambled word = word
            if (scrambled == word) {
                Debug.Log("Fixed");
            } else if (scrambled != word) {
                go = false;
            }
        }
        return scrambled;
    }

    char randomChoice(List<char> list) {
        float length = list.Count;
        float rawIndex = Mathf.Floor(Random.Range(0f, length));
        int index = (int) rawIndex;
        char randomChar = list[index];
        return randomChar;
    }
}
