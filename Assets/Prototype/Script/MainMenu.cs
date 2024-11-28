using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingMenu;


    private void Start()
    {

    }
    public void StarGame()
    {
        Audio.Instance.PlaySFX("Click");
        Audio.Instance.musicSource.Stop();
        Audio.Instance.PlayMusic("ThemeLobby");
        SceneTransition.instance.NextLevel(1);
    }
 
public void OpenSetting()
    {
        Audio.Instance.PlaySFX("Click");
        SettingMenu.SetActive(true);
    }
    public void CloseSetting()
    {
        Audio.Instance.PlaySFX("Click");
        SettingMenu.SetActive(false);
    }
    public void ExitGame()
    {
        Audio.Instance.PlaySFX("Click");
        Debug.Log("Exit");
        Application.Quit();

    }


}
