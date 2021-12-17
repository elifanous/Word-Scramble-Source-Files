using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeBtnClick : MonoBehaviour
{
    void Start() {
        Button homeBtn = gameObject.GetComponent<Button>();
        homeBtn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick() {
        SceneManager.LoadScene("MainMenu");
    }
}
