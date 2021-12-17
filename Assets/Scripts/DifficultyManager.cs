using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    public string difficulty {
        get { return PlayerPrefs.GetString("difficulty"); }
        set { PlayerPrefs.SetString("difficulty", value); }
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
    public Button EasyBtn, MediumBtn, HardBtn;
    public Text EasyHighScore, MediumHighScore, HardHighScore;

    void Start() {
        EasyHighScore.text = "High Score: " + easyHighScore;
        MediumHighScore.text = "High Score: " + mediumHighScore;
        HardHighScore.text = "High Score: " + hardHighScore;
        EasyBtn.onClick.AddListener(easyBtnClick);
        MediumBtn.onClick.AddListener(mediumBtnClick);
        HardBtn.onClick.AddListener(hardBtnClick);
    }

    void easyBtnClick() {
        difficulty = "easy";
        SceneManager.LoadScene("Main");
    }

    void mediumBtnClick() {
        difficulty = "medium";
        SceneManager.LoadScene("Main");
    }
    
    void hardBtnClick() {
        difficulty = "hard";
        SceneManager.LoadScene("Main");
    }
}
