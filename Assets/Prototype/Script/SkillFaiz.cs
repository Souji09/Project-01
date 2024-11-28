using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillFaiz : MonoBehaviour
{
    public Slider cooldownSlider;

    private float cooldown = 50f;
    public float Currentcooldown;
 
    public float SkillReady = 0f;

    private float TimeOut;
    public GameObject[] smoke;

    public TextMeshProUGUI TextCoolDonw;

    [SerializeField] public Animator ani;
    public bool canBoost;
    private bool Boosting;
    private bool CanStartTimeout;
    void Start()
    {
        Currentcooldown = cooldown;
        canBoost = true;
        Boosting = false;
        CanStartTimeout = false;
        foreach (var n in smoke)
        {
            n.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.E) && canBoost)
        {
            StartCoroutine(Boost());
        }
        

        if (Boosting)
        {
            if (Boosting == true && CanStartTimeout == true )
            {
                TimeOut -= Time.deltaTime;
            }
            if (TimeOut <= 0)
            {
                TimeOut = 0;
                CanStartTimeout = false;
            }
        }
        
        Cooldown();
        UpdateCooldown();


    }

    private void UpdateCooldown()
    {
        cooldownSlider.value = Cal();
        
        TextCoolDonw.text = "0"+TimeOut.ToString("F2");
    }
    private float Cal()
    {
        return Currentcooldown / cooldown;
    }

    private void Cooldown()
    {
        if (Currentcooldown >= cooldown)
        {
            canBoost = true;
        }
        if(Boosting == false)
        {
            Currentcooldown += Time.deltaTime;
        }
    }
    IEnumerator Boost()
    {
        ani.SetTrigger("Start");
        canBoost = false;
        Boosting = true;
        Currentcooldown = 0f;
        Audio.Instance.PlaySFX("Boost");
        
        TimeOut = 10f;

        yield return new WaitForSeconds(3f);
        CanStartTimeout = true;
        foreach (var n in  smoke)
        {
            n.SetActive(true);
        }

        PlayerController.instance.speed = 7f;
        Audio.Instance.musicSource.Pause();

        yield return new WaitForSeconds(10);
        Audio.Instance.musicSource.UnPause();
        foreach (var n in smoke)
        {
            n.SetActive(false);
        }
        ani.SetTrigger("End");
        PlayerController.instance.speed = 2f;
        Boosting = false;



    }
}
