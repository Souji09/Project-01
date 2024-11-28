using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChooseCharater : MonoBehaviour
{
    [SerializeField] public GameObject[] player;
    public GameObject[] Panel;
    public GameObject playe;
    private void Update()
    {
        if(playe != null)
        {
            Destroy(gameObject);
        }
        else
        {
            playe = GameObject.FindGameObjectWithTag("Player");
        }
    }
    public void Back()
    {
        Audio.Instance.PlaySFX("Click");
        foreach (var n in Panel)
        {
            n.SetActive(false);
        }
    }

    public void ChooseFaiz()
    {
        Audio.Instance.PlaySFX("Click");
        foreach (var n in Panel)
        {
            n.SetActive(false);
        }
        Panel[0].SetActive(true);
    }

    public void UsingFaiz()
    {
        Audio.Instance.PlaySFX("Click");
        GameObject newPlayer = Instantiate(player[0], transform.position, Quaternion.identity);
        newPlayer.transform.localScale = player[0].transform.localScale; // Đặt lại tỷ lệ
        foreach (var n in Panel)
        {
            n.SetActive(false);
        }
    }

    public void ChooseIrene()
    {
        Audio.Instance.PlaySFX("Click");
        foreach (var n in Panel)
        {
            n.SetActive(false);
        }
        Panel[1].SetActive(true);
    }

    public void UsingIrene()
    {
        Audio.Instance.PlaySFX("Click");
        GameObject newPlayer = Instantiate(player[1], transform.position, Quaternion.identity);
        newPlayer.transform.localScale = player[1].transform.localScale; // Đặt lại tỷ lệ
        foreach (var n in Panel)
        {
            n.SetActive(false);
        }
    }
}
