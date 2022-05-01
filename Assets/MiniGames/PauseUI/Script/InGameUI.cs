using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    public GameObject Blind;
    public GameObject UISet;
    public GameObject PauseButton;
    public GameObject CountButton;
    public GameObject ExitButton;
    public void Pause()
    {
        GameManager.Instance.Pause = true;
        Time.timeScale = 0;
        Blind.SetActive(true);
        PauseButton.SetActive(false);
        UISet.SetActive(true);
    }
    public void Resume()
    {
        GameManager.Instance.Pause = false;
        Blind.SetActive(false);
        PauseButton.SetActive(true);
        UISet.SetActive(false);
        Time.timeScale = GameManager.Instance.LevelTimeScale();
    }
    public void GotoMainBoard()
    {
        GameManager.Instance.Pause = false;
        Blind.SetActive(false);
        PauseButton.SetActive(true);
        UISet.SetActive(false);
        SceneManager.LoadScene("MainBoard");
    }
}
