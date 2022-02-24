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

    public bool BGMOn = true;
    public bool SFXOn = true;

    public List<Sprite> sprites;
    public Image BGMImg;
    public Image SFXImg;

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
    /*
    public void SetMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }
    public void SetSEVolume(float volume)
    {
        SEvolume = volume;
    }
    */
    public void BGMOnOff()
    {
        switch (BGMOn)
        {
            case false:
                // BGMBar.image.color = Color.green;
                BGMImg.sprite = sprites[0];
                audioSource.volume = 100;
                BGMOn = true;
                PlayerPrefs.SetInt("BGMOn", BGMOn == false ? 0 : 1);
                break;
            case true:
                //BGMBar.image.color = Color.red;
                BGMImg.sprite = sprites[1];
                audioSource.volume = 0;
                BGMOn = false;
                PlayerPrefs.SetInt("BGMOn", BGMOn == false ? 0 : 1);
                break;
        }
    }
    public void SFXOnOff()
    {
/*        switch (SFXOn)
        {
            case false:
                SFXBar.image.color = Color.green;
                SFXImg.sprite = sprites[0];
                SEvolume = 100;
                SFXOn = true;
                PlayerPrefs.SetInt("SFXOn", SFXOn == false ? 0 : 1);
                break;
            case true:
                SFXBar.image.color = Color.red;
                SFXImg.sprite = sprites[1];
                SEvolume = 0;
                SFXOn = false;
                PlayerPrefs.SetInt("SFXOn", SFXOn == false ? 0 : 1);
                break;
        }*/
        SFXImg.sprite = sprites[SFXOn ? 1 : 0];
        SEvolume = SFXOn ? 0 : 100;
        SFXOn = !SFXOn;
        PlayerPrefs.SetInt("SFXOn", SFXOn ? 0 : 1);
    }
    private void Start()
    {
        BGMOn = PlayerPrefs.GetInt("BGMOn") == 0 ? false : true;
        SFXOn = PlayerPrefs.GetInt("SFXOn") == 0 ? false : true;
        SFXImg.sprite = sprites[0];
        if (SFXOn) SFXImg.sprite = sprites[0];
        else SFXImg.sprite = sprites[1];
        if (BGMOn) BGMImg.sprite = sprites[0];
        else BGMImg.sprite = sprites[1];
    }
}
