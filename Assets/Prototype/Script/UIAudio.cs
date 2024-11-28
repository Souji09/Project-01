using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAudio : MonoBehaviour
{
    public Slider musicslider, sfxslider;
    public void ToggleMusic()
    {
        Audio.Instance.SettingMusic();
    }
    public void ToggleSFX()
    {
        Audio.Instance.SettingSFX();
    }
    public void MusicVolume()
    {
        Audio.Instance.MusicVolume(musicslider.value);
    }
    public void SFXVolume()
    {
        Audio.Instance.SFXVolume(sfxslider.value);
    }
}
