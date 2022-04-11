using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootSound : MonoBehaviour
{
    [SerializeField] Slider shootSlider;
  
    void Start()
    {
        if (!PlayerPrefs.HasKey("ShootVolume"))
        {
            PlayerPrefs.SetFloat("ShootVolume",1);
            LoadShootSound();
        }
        else
        {
            LoadShootSound();
        }
    }

    public void ChangeSoundShoot()
    {
        AudioListener.volume = shootSlider.value;
        SaveShootSound();
    }

    void LoadShootSound()
    {
        shootSlider.value = PlayerPrefs.GetFloat("ShootVolume");
        
    }

    void SaveShootSound()
    {
        PlayerPrefs.SetFloat("ShootVolume", shootSlider.value);
        
    }  
}
