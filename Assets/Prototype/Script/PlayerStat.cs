using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;
using UnityEngine.SocialPlatforms;

public class PlayerStat : MonoBehaviour
{
    public static PlayerStat playerStats;
    
    public int currentlevel;

    public int SlimeKilled;
    public int MageKilled;
    public int BossKilled;
    public int healingPotion;
    public float Lheal = 20;
    public TextMeshProUGUI level;
    public TextMeshProUGUI Potion;

    public CinemachineVirtualCamera virtualCamera;

    public GameObject player;

    public Slider healthSlider;
    public Text healthtext;
    
    public float maxhealth = 50;
    public float currhealth;

    public float maxTheLuc = 120.0f;
    public float currentTheLuc;
    public Slider TheLucSlider;

    public float speed = 2.0f;

    public int Armor = 10;
    public Text ArmorText;

    public float DPS = 10.0f;
    public Text DpsText;

    public int Ingot;
    public Text IngotValue;

    public int EXP;
    public Text ExpValue;


    public GameObject deathDisplayScore;

    private Coroutine staminaRegenCoroutine;


    public bool Isbatu;
    public void Awake()
    {
        if (playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        deathDisplayScore.SetActive(false);
        virtualCamera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
        currentlevel = 0;
        currhealth = maxhealth;
        currentTheLuc = maxTheLuc;
        healingPotion = 5;
        ArmorText.text = "" + Armor.ToString();
        DpsText.text = "" + DPS.ToString();

        UpdatehealthUI();
        UpdateStaninaUI();
        UpdateLevel();
        UpdatePotion();
        Isbatu = false;
        SlimeKilled = 0;
        MageKilled = 0;
        BossKilled = 0;

}
    public void UpDateDameAndArmorUI()
    {
        ArmorText.text = "" + Armor.ToString();
        DpsText.text = "" + DPS.ToString();

    }
    public void changeHealth(float dame)
    {
        if (Isbatu != true)
        {
            currhealth = Mathf.Clamp(currhealth + (dame - Armor), 0, maxhealth);
            UpdatehealthUI();
            checkDealth();
        }
    }
   
    public void changeTheLuc(float amount)
    {
        currentTheLuc = Mathf.Clamp(currentTheLuc - amount, 0, maxTheLuc);
        TheLucSlider.value = CaltheLuc();
        if (staminaRegenCoroutine != null)
        {
            StopCoroutine(staminaRegenCoroutine);
        }
        staminaRegenCoroutine = StartCoroutine(hoiTheLuc(1));

    }
    void checkDealth()
    {
        if (currhealth <= 0)
        {
            Audio.Instance.sfxSource.Stop();
            Audio.Instance.PlaySFX("Death");
            
            Destroy(player,0.1f);
            deathDisplayScore.SetActive(true);
            Time.timeScale = 0f;
        }

    }
    private float CalHp()
    {
        return (currhealth / maxhealth);
    }
    private float CaltheLuc()
    {
        return (currentTheLuc / maxTheLuc);
    }

    public void AddCurrency(PickupIngot SoLuong)
    {
        if (SoLuong.currentObject == PickupIngot.pickupObject.INGOT)
        {
            Ingot += SoLuong.pickupQuantity;
            UpdateIngot();
        }
    }
    public void UpdateEXp()
    {
        ExpValue.text = EXP.ToString();
    }
    public void UpdateIngot() 
    {
        IngotValue.text = "X " + Ingot.ToString();
    }
    
    public void UpdatehealthUI()
    {
        healthSlider.value = CalHp();
        healthtext.text = Mathf.Ceil(currhealth).ToString() + "/" + maxhealth.ToString();
    }
    public void UpdateStaninaUI()
    {
        TheLucSlider.value = CaltheLuc();

    }
    IEnumerator hoiTheLuc(float delay)
    {
        yield return new WaitForSeconds(delay);
        while (currentTheLuc < maxTheLuc)
        {
            currentTheLuc = Mathf.Clamp(currentTheLuc + 20 * Time.deltaTime, 0, maxTheLuc);
            UpdateStaninaUI();
            yield return null;
        }
        
    }
    public void ResetStats()
    {
        currhealth = maxhealth;
        currentTheLuc = maxTheLuc;
        Armor = 7;
        DPS = 10.0f;
        Ingot = 0;
        EXP = 0;
        UpdatehealthUI();
        UpdateStaninaUI();
    }
    public void HealingUse()
    {
       
            currhealth = Mathf.Clamp(currhealth + Lheal, 0, maxhealth);
            UpdatehealthUI();
  
    }
    public void UpdateLevel()
    {
        level.text = "Level:" + currentlevel.ToString();
    }
    public void UpdatePotion()
    {
        Potion.text = ":" + healingPotion.ToString();
    }
}

