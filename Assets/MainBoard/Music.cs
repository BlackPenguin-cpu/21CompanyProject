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

        /*�������
        �������� - BGM���丮 (https://bgmfactory.com)
        ������� - ��� ���� ����
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
