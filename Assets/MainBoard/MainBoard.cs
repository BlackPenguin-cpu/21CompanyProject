using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainBoard : MonoBehaviour
{
    // Start is called before the first frame update
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
       // SoundManager.Instance.Playbgm("메인화면");

        Debug.Log("확인 gogo");
        SoundManager.Instance.PlaySound("Game_start");
        GameManager.Instance.GameStart();
    }

    public void ClickSound()
    {
        SoundManager.Instance.PlaySound("Button_Click");
    }
}
