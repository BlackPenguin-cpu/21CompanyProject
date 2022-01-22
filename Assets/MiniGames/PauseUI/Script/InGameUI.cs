using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public GameObject Blind;
    public GameObject UISet;
    public GameObject PauseButton;
    public GameObject CountButton;
    public GameObject ExitButton;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0;
        Blind.SetActive(true);
        PauseButton.SetActive(false);
        UISet.SetActive(true);
    }
}
