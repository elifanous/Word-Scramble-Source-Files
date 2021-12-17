using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject Part1, Part2;
    public Button PlayBtn, ExitBtn, BackBtn;

    void Start() {
        Part1.SetActive(true);
        Part2.SetActive(false);
        PlayBtn.onClick.AddListener(PlayBtnClick);
        ExitBtn.onClick.AddListener(ExitBtnClick);
        BackBtn.onClick.AddListener(BackBtnClick);
    }

    void PlayBtnClick() {
        Part1.SetActive(false);
        Part2.SetActive(true);
    }
    void ExitBtnClick() {
        Debug.Log("Exited game");
        Application.Quit();
    }
    void BackBtnClick() {
        Part1.SetActive(true);
        Part2.SetActive(false);
    }
}
