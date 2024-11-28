using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI mage;
    public TextMeshProUGUI slime;
    public TextMeshProUGUI boss;
    public TextMeshProUGUI floor;
    public TextMeshProUGUI totalScore;
    public TextMeshProUGUI HightScore;
    private int Slimekillded;
    private int Magekllded;
    private int totalkillded;
    private int bosskillded;
    private int floorPassed;
    private int TotalScore;
    private void Start()
    {
        HightScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    private void Update()
    {
        Magekllded = PlayerStat.playerStats.MageKilled;
        Slimekillded = PlayerStat.playerStats.SlimeKilled;
        bosskillded = PlayerStat.playerStats.BossKilled;
        floorPassed = Floor.instance.CurrentFloor;
        TotalScore = totalkillded + Magekllded + Slimekillded + (100 * bosskillded) + floorPassed;

        if (TotalScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", TotalScore);
            HightScore.text = TotalScore.ToString();
        }

        UpdateScore();
    }
    public void Returnlobby()
    {
        
        Time.timeScale = 1f;
        Audio.Instance.PlaySFX("Click");
        
        Audio.Instance.PlayMusic("ThemeLobby");
        Destroy(PauseMenu.instance.gameObject,0.2f);
        Destroy(PlayerStat.playerStats.gameObject,0.2f);
        SceneTransition.instance.NextLevel(1);


    }
    public void ReturnMainmenu()
    {
        
        Time.timeScale = 1f;
        Audio.Instance.PlaySFX("Click");

        StartCoroutine(LoadMainMenu());
    }
    IEnumerator LoadMainMenu()
    {
        
        Destroy(PauseMenu.instance.gameObject,0.2f);
        Destroy(PlayerStat.playerStats.gameObject,0.2f);
        Audio.Instance.PlayMusic("MainMenuTheme");
        SceneTransition.instance.NextLevel(0);
        yield return null;
    }

    public void UpdateScore()
    {
        mage.text = "" + Magekllded.ToString();
        slime.text = "" + Slimekillded.ToString();
        boss.text = "" + bosskillded.ToString();
        floor.text = "" + floorPassed.ToString();
        totalScore.text = TotalScore.ToString();
    }
}
