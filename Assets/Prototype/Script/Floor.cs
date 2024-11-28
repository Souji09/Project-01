using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public static Floor instance;
    public int CurrentFloor;
    public int FightFloor;
    public TextMeshProUGUI floor;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        FightFloor = 0 ;
        CurrentFloor = 0;
    }

    // Update is called once per frame
    public void UpdateFloor()
    {
        floor.text = "Floor:" + CurrentFloor.ToString();
    }
    public void Plus1Floor()
    {
        CurrentFloor++;
        UpdateFloor();
    }
}
