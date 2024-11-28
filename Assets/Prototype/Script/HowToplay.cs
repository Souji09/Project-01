using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToplay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;

    private void Start()
    {
        panel.SetActive(false);
    }
    public void back()
    {
        Audio.Instance.PlaySFX("Click");
        panel.SetActive(false);
    }
    public void Display()
    {
        Audio.Instance.PlaySFX("Click");
        panel.SetActive(true);
    }
}
