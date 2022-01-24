using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public GameObject PauseButton;
    public GameObject UISet;
    void Start()
    {

    }

    void Update()
    {

    }

    public void PauseButtonClick()
    {
        Time.timeScale = 0;
        PauseButton.SetActive(false);
        UISet.SetActive(true);
    }

    public void ContinueButtonClick()
    {
        Time.timeScale = 1;
        UISet.SetActive(false);
        PauseButton.SetActive(true);
    }

    public void ExitButtonClick()//������ ��ư �������� Ÿ�̸� UI�ʱ�ȭ �ϸ� �ɵ�
    {
        UISet.SetActive(false);
        PauseButton.SetActive(true);
        SceneManager.LoadScene("MainBoard");
        Time.timeScale = 1;
    }
}
