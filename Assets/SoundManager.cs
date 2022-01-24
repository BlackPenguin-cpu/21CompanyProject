using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[System.Serializable]
public class Clip
{
    public string Name;
    public AudioClip clip;
}
public class SoundManager : Singleton<SoundManager>
{
    public AudioSource audioSource;
    public List<Clip> clips;
    public Button BGMBar;
    public Button SFXBar;
    public bool On = true;
    public bool SFXOn = true;

    public List<Sprite> sprites;
    public Image Bgmimg;
    public Image Sfximg;

    float SEvolume = 1;
    protected SoundManager() { }

    public void Playbgm(string name)
    //»ç¿ë¹ý SoundManager.Instance.Playbgm("string");
    {
        Clip find = clips.Find((o) => { return o.Name == name; });
        if (find != null)
        {
            audioSource.Stop();
            audioSource.clip = find.clip;
            audioSource.loop = true;
            audioSource.Play();

        }
      

    }

    public void PlaySound(string _clip)
    {
        Clip find = clips.Find((o) => { return o.Name == _clip; });
        if (find != null)
        {
            GameObject audio_object = new GameObject();
            AudioSource object_source = audio_object.AddComponent<AudioSource>();
            object_source.volume = SEvolume;
            object_source.clip = find.clip;
            object_source.loop = false;
            object_source.Play();

            Destroy(audio_object, find.clip.length);
        }
    }
    public void PlaySound(AudioClip _clip)
    {
        GameObject audio_object = new GameObject();
        AudioSource object_source = audio_object.AddComponent<AudioSource>();
        object_source.volume = SEvolume;
        object_source.clip = _clip;
        object_source.loop = false;
        object_source.Play();

        Destroy(audio_object, _clip.length);
    }

    public void SetMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }
    public void SetSEVolume(float volume)
    {
        SEvolume = volume;
    }
    void Update()
    {
        //BGMOnOff();
        //SFXOnOff();
    }

    public void BGMOnOff()
    {
        switch (On)
        {
            case true:
                // BGMBar.image.color = Color.green;
                Bgmimg.sprite = sprites[0];
                audioSource.volume = 100;
                break;
            case false:
                //BGMBar.image.color = Color.red;
                Bgmimg.sprite = sprites[1];
                audioSource.volume = 0;
                break;
        }
    }

    public void BGMClick()
    {
        if (On)
        {
            On = false;
        }
        else if (On == false)
        {
            On = true;
        }
    }

    public void SFXOnOff()
    {
        switch (SFXOn)
        {
            case true:
                //SFXBar.image.color = Color.green;
                Sfximg.sprite = sprites[0];
                SEvolume = 100;
                break;
            case false:
                //SFXBar.image.color = Color.red;
                Sfximg.sprite = sprites[1];
                SEvolume = 0;
                break;
        }
    }

    public void SFXClick()
    {
        if (SFXOn)
        {
            SFXOn = false;
        }
        else if (SFXOn == false)
        {
            SFXOn = true;
        }
    }
}
