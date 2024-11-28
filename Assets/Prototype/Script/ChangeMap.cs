using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMap : MonoBehaviour
{
    public static ChangeMap GoToNewMap;
    [SerializeField] public GameObject[] Map;
    [SerializeField] public GameObject BossMap;

    private void Awake()
    {
        GoToNewMap = this;
    }


    public void ChooseMapFight()
    {
        Audio.Instance.PlaySFX("boop");
        Floor.instance.Plus1Floor();
        SceneTransition.instance.NextLevel(2); ;
        DeactivateAllMaps();
        ResetPlayerPosition();

    }
    public void ChooseMapLevelUp()
    {
        Audio.Instance.PlaySFX("boop");
        Floor.instance.Plus1Floor();
        SceneTransition.instance.NextLevel(3);
        DeactivateAllMaps();
        ResetPlayerPosition();


    }
    public void ChoosMapElite()
    {
        Audio.Instance.PlaySFX("boop");

        Floor.instance.Plus1Floor();
        SceneTransition.instance.NextLevel(4);
        DeactivateAllMaps();
        ResetPlayerPosition();


    }

    public void ChoosMapBoss()
    {

        Audio.Instance.PlaySFX("boop");
        Floor.instance.Plus1Floor();
        SceneTransition.instance.NextLevel(5);
        DeactivateAllMaps();
        ResetPlayerPosition();



    }
    public void DisPlayMap()
    {
        if (Floor.instance.FightFloor >= 4)
        {
            BossMap.SetActive(true);
            Floor.instance.FightFloor = 0;
        }
        else
        {
            // Tắt tất cả các map trước khi hiển thị map mới
            foreach (GameObject map in Map)
            {
                map.SetActive(false);
            }

            // Random một map từ danh sách và hiển thị
            int randomIndex = Random.Range(0, Map.Length);
            Map[randomIndex].SetActive(true);
        }
    }
    private void DeactivateAllMaps()
    {
        // Tắt tất cả các map
        foreach (GameObject map in Map)
        {
            map.SetActive(false);
        }
        // Tắt cả phòng boss
        BossMap.SetActive(false);
    }
    public void ResetPlayerPosition()
    {
        StartCoroutine(StartReset());
    }
    IEnumerator StartReset()
    {
        // Đặt lại vị trí người chơi về (0, 0, 0)

        yield return new WaitForSeconds(1f);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = Vector3.zero;
    }
    
}
