using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSound : MonoBehaviour
{

    [SerializeField] Slider musicSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
            LoadSoundMusic();
        }
        else
        {
            LoadSoundMusic();
        }
    }

    public void ChangeSoundMusic()
    {
        AudioListener.volume = musicSlider.value;
    }

    void LoadSoundMusic()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    void SaveSoundMusic()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }


}
