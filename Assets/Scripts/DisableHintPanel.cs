using UnityEngine;
using UnityEngine.UI;

public class DisableHintPanel : MonoBehaviour
{
    public Timer timer;
    public Animator animator;
    public Button xBtn;

    void Start() {
        xBtn.onClick.AddListener(xBtnClick);
    }

    void xBtnClick() {
        animator.Play("HideHintPanel");
        timer.timerIsRunning = true;
    }

    public void DHP() {
        this.gameObject.SetActive(false);
    }
}
