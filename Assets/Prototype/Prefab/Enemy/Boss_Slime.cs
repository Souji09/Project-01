using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss_Slime : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject healthbar;
    public Slider HealthBarSlider;

    private float maxhealth = 3000;
    private float currenthealth;
    private float speed =1.6f;
    private float dame = 5;

    public GameObject Ingot;
    public GameObject SlimeMini;
    private GameObject player;

    bool IsDamed;

    private Coroutine dameCoroutine;
    Rigidbody rb;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currenthealth = maxhealth;
        healthbar.SetActive(true);
        IsDamed = false;
        UpdateStatsBasedOnFloor();
        Audio.Instance.musicSource.Stop();
        Audio.Instance.PlayMusic("BossTheme");
        StartCoroutine(SpawnSlime());
    }
    private void FixedUpdate()
    {
        if (player != null)
        {
            FindPlayer();
        }
        SpawnSlime();
    }

    public void changeHealth(float dame)
    {
        currenthealth = Mathf.Clamp(currenthealth + dame, 0, maxhealth);
        HealthBarSlider.value = CalHealth();
        checkdead();
    }

    private float CalHealth()
    {
        return currenthealth / maxhealth;
    }
    private void checkdead()
    {
        if (currenthealth <= 0)
        {
            healthbar.SetActive(false);
            int rate = Random.Range(1, 11);
            for(int i = 0; i < rate;i++)
            {
                Instantiate(Ingot, transform.position, Quaternion.identity);
            }
            PlayerStat.playerStats.EXP += 100+(Floor.instance.CurrentFloor * 5);
            PlayerStat.playerStats.UpdateEXp();
            PlayerStat.playerStats.BossKilled += 1;
            OnDestroy();

        }


    }
    private void OnDestroy()
    {
        Destroy(gameObject);
        Audio.Instance.musicSource.Stop();
        Audio.Instance.PlayMusic("NormalTheme");
        ChangeMap.GoToNewMap.DisPlayMap();
    }
    void FindPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Player")
            {
                if (dameCoroutine == null)
                {
                    dameCoroutine = StartCoroutine(damePlayer());
                }
            }
        }
    }
    void UpdateStatsBasedOnFloor()
    {

        maxhealth +=   (Floor.instance.CurrentFloor * 20); // Thay đổi các giá trị này tùy thuộc vào yêu cầu của bạn
        dame +=  (Floor.instance.CurrentFloor * 2);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.tag == "Player")
        {
            StopCoroutine(dameCoroutine);
            IsDamed = false;
            dameCoroutine = null;
        }
    }

    IEnumerator damePlayer()
    {

        while (true)
        {
            while (IsDamed == false)
            {
                PlayerStat.playerStats.changeHealth(-dame);
                IsDamed = true;
                yield return new WaitForSeconds(1f);
                IsDamed = false;
            }
            yield return null;

        }


    }
    IEnumerator SpawnSlime()
    {
        Vector2 pos = transform.position;

        Instantiate(SlimeMini,pos,Quaternion.identity);
        yield return new WaitForSeconds(1f) ;
    }
}
