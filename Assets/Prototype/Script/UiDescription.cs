using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiDescription : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI text;
    public GameObject Image;
    public float cooldown=3f;
    public Animator animator;
    private void Start()
    {
        animator.SetBool("FadeNow",false);
        Image.SetActive(true);     
    }
    private void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            
            animator.SetBool("FadeNow",true);
        }
    }
}
