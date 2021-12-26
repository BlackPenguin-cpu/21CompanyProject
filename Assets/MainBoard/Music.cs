using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public AudioSource Source;
    public AudioSource btnsource;

    public void MusicVolume(float volume)
    {
        Source.volume = volume;

        /*배경음악
        음원제공 - BGM팩토리 (https://bgmfactory.com)
        사용음원 - 기분 좋은 느낌
        */


    }
    public void btnMusicVolume(float volume)
    {
        btnsource.volume = volume;

    }

    public void OnSFX()
    {
        btnsource.Play();
    }
}
