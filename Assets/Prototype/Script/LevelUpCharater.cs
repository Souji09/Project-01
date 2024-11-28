using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpCharater : MonoBehaviour
{
    public static LevelUpCharater levelCharater;

    public GameObject LevelUpManager;
    public TextMeshProUGUI PriceLevelUp;
    int TotalPrice;
    int total;
    void Start()
    {
        LevelUpManager.SetActive(false);
        
        TotalPrice =0;
        total = 2;
        CalPrice();
        TextUpdatePrice();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            LevelUpManager.SetActive(true);
            TestSpell Irene = FindObjectOfType<TestSpell>();
            FaiZGun Faiz = FindObjectOfType<FaiZGun>();
            if(Irene != null)
            {
                Irene.CanShoot = false;
            }
            if (Faiz != null)
            {
                Faiz.CanShoot = false;
            }
        }                      
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LevelUpManager.SetActive(false);
            TestSpell Irene = FindObjectOfType<TestSpell>();
            FaiZGun Faiz = FindObjectOfType<FaiZGun>();
            if (Irene != null)
            {
                Irene.CanShoot = true;
            }
            if (Faiz != null)
            {
                Faiz.CanShoot = true;
            }
        }

    }
    public void LevelUpHp()
    {
        Audio.Instance.PlaySFX("boop");
        if (PlayerStat.playerStats.EXP >= TotalPrice) 
        {
            PlayerStat.playerStats.EXP -= TotalPrice;
            PlayerStat.playerStats.UpdateEXp();
            CalPrice();
            TextUpdatePrice();

            PlayerStat.playerStats.currentlevel++;
            PlayerStat.playerStats.UpdateLevel();

            PlayerStat.playerStats.maxhealth += 10;
            PlayerStat.playerStats.currhealth += 10;       
            PlayerStat.playerStats.UpdatehealthUI();
                       
            
        }
        
    }
    public void LevelUpLheal()
    {
        Audio.Instance.PlaySFX("boop");
        if (PlayerStat.playerStats.EXP >= TotalPrice)
        {
            PlayerStat.playerStats.EXP -= TotalPrice;
            CalPrice();
            PlayerStat.playerStats.UpdateEXp();

            PlayerStat.playerStats.Lheal += 10;
            
            TextUpdatePrice();
            
        }
    }
    public void LevelUpArmor()
    {
        Audio.Instance.PlaySFX("boop");
        if (PlayerStat.playerStats.EXP >= TotalPrice)
        {
            PlayerStat.playerStats.EXP -= TotalPrice;
            PlayerStat.playerStats.UpdateEXp();

            CalPrice();
            TextUpdatePrice();

            PlayerStat.playerStats.currentlevel++;
            PlayerStat.playerStats.UpdateLevel();

            
            PlayerStat.playerStats.Armor += 5;
            PlayerStat.playerStats.UpDateDameAndArmorUI();

            
            
            
        }
    }
    public void LevelUpDPS()
    {
        Audio.Instance.PlaySFX("boop");
        if (PlayerStat.playerStats.EXP >= TotalPrice)
        {
            PlayerStat.playerStats.EXP -= TotalPrice;
            PlayerStat.playerStats.UpdateEXp();

            PlayerStat.playerStats.currentlevel++;
            PlayerStat.playerStats.UpdateLevel();

            PlayerStat.playerStats.DPS += 5;
            PlayerStat.playerStats.UpDateDameAndArmorUI();
            CalPrice();
            TextUpdatePrice();
            
        }
    }
    public void LevelStamina()
    {
        Audio.Instance.PlaySFX("boop");
        if (PlayerStat.playerStats.EXP >= TotalPrice)
        {
            PlayerStat.playerStats.currentlevel++;
            PlayerStat.playerStats.maxTheLuc += 10;

            PlayerStat.playerStats.UpdateLevel();
            PlayerStat.playerStats.EXP -= TotalPrice;
            PlayerStat.playerStats.UpdateEXp();
            CalPrice();

            PlayerStat.playerStats.UpdateStaninaUI();
            TextUpdatePrice();
            
            
        }
    }
    public void BuyHealthPotion()
    {

        Audio.Instance.PlaySFX("boop");
        if (PlayerStat.playerStats.Ingot >= 2)
            {
                
                PlayerStat.playerStats.healingPotion += 1;
                PlayerStat.playerStats.UpdatePotion();
                PlayerStat.playerStats.Ingot -= 2;
                PlayerStat.playerStats.UpdateIngot();
                
            }
        
    }
    private void CalPrice()
    {
        TotalPrice += total + Floor.instance.CurrentFloor;
    }
    private void TextUpdatePrice()
    {
        PriceLevelUp.text = "-"+TotalPrice.ToString()+" to Level Up Your Level";
    }

}
