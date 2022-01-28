using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("BackgroundMusic"))
        {
            PlayerPrefs.SetFloat("BackgroundMusic", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("BackgroundMusic");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("BackgroundMusic", volumeSlider.value);
    }
}
