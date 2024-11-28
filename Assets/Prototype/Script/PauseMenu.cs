using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    public GameObject pauseMenu;
    public GameObject SettingMenu;
    public GameObject warning;

    bool pausegame;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        pauseMenu.SetActive(false);
        pausegame = false;
        warning.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausegame)
            {
                Resume();
            }
            else
            {
                isPause();
            }
        }
    }

    public void isPause()
    {
        Audio.Instance.PlaySFX("Click");
        pausegame = true;
        pauseMenu.SetActive(true);
        warning.SetActive(false);
        UpdateShootingState(false); // Sử dụng phương thức để cập nhật trạng thái bắn
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        Audio.Instance.PlaySFX("Click");
        pausegame = false;
        pauseMenu.SetActive(false);
        warning.SetActive(false);
        SettingMenu.SetActive(false);
        UpdateShootingState(true); // Sử dụng phương thức để cập nhật trạng thái bắn
    }

    private void UpdateShootingState(bool canShoot)
    {
        TestSpell Irene = FindObjectOfType<TestSpell>();
        FaiZGun Faiz = FindObjectOfType<FaiZGun>();
        if (Irene != null)
        {
            Irene.CanShoot = canShoot;
        }
        if (Faiz != null)
        {
            Faiz.CanShoot = canShoot;
        }
    }

    public void Yes()
    {
        Audio.Instance.PlaySFX("Click");
        Time.timeScale = 1f;
        StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadMainMenu()
    {
        SceneTransition.instance.NextLevel(0);

        Destroy(PauseMenu.instance.gameObject);
        Destroy(PlayerStat.playerStats.gameObject);
        Audio.Instance.PlayMusic("MainMenuTheme");
        yield return null;
    }

    public void No()
    {
        warning.SetActive(false);
        Audio.Instance.PlaySFX("Click");
    }

    public void Warning()
    {
        Audio.Instance.PlaySFX("Click");
        warning.SetActive(true);
    }

    public void Setting()
    {
        Audio.Instance.PlaySFX("Click");
        SettingMenu.SetActive(true);
    }

    public void CloseSetting()
    {
        Audio.Instance.PlaySFX("Click");
        SettingMenu.SetActive(false);
    }
}
