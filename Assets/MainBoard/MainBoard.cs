using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainBoard : MonoBehaviour
{
    bool isClicked;
    public Image FadeScreen;
    void Start()
    {
        SoundManager.Instance.Playbgm("Main_BGM");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GoGame()
    {
        if (!isClicked)
        {
            StartCoroutine(GoGameCorutine());
            isClicked = true;
        }
    }
    IEnumerator GoGameCorutine()
    {
        SoundManager.Instance.PlaySound("Game_start");
        FadeScreen.color = new Color(1, 1, 1, 0);
        while (FadeScreen.color.a < 1)
        {
            FadeScreen.color += new Color(0, 0, 0, 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        GameManager.Instance.GameStart();
    }

    public void ClickSound()
    {
        SoundManager.Instance.PlaySound("Button_Click");
    }
}
