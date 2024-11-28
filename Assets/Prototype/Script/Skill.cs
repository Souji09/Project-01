using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public static Skill Instance;
    public GameObject VatThe;
    public float Force = 10.0f;
    public int Count = 5;
    public float Time = 0.1f;
    public int numberOfBullets = 5; // Số lượng đạn bắn ra
    public float angleSpread = 15.0f; // Góc lệch giữa các viên đạn

    public Slider SkilSlider;


    public int skillpoint { get; set; }
    public int skillReady = 80;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public bool CanUseSkill;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        CanUseSkill = true;
        skillpoint = 80;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        UpdateSkillUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CanUseSkill == true)
        {
            CameraShake.instance.ShakeCamera();
            StartCoroutine(ShootBurt());
            skillpoint = 0;
            CanUseSkill = false;
            UpdateSkillUI();
        }
        else
        {
            return;
            
        }
        UpdateSkillUI();
    }
    public void CheckSkillready(int point)
    {
        skillpoint = Mathf.Clamp(skillpoint + point, 0, skillReady);
        UpdateSkillUI();
        if ( skillpoint == skillReady)
        {
            CanUseSkill = true;
        }
        
    }
    public void UpdateSkillUI()
    {
        SkilSlider.value = CalpointSkill();
    }
    public float CalpointSkill()
    {
        return (float) skillpoint / skillReady;
    }
    
    IEnumerator ShootBurt()
    {
        for (int i = 0; i < 15; i++)
        {
            ShootBullets();
            yield return new WaitForSeconds(Time);
        }
        
    }
    void ShootBullets()
    {
        Audio.Instance.PlaySFX("Shoot");
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 baseDirection = (mousePos - (Vector2)transform.position).normalized;

        float baseAngle = Mathf.Atan2(baseDirection.y, baseDirection.x) * Mathf.Rad2Deg;

        for (int i = 0; i < numberOfBullets; i++)
        {
            float currentAngle = baseAngle + (i - numberOfBullets / 2) * angleSpread;
            float radianAngle = currentAngle * Mathf.Deg2Rad;

            Vector2 direction = new Vector2(Mathf.Cos(radianAngle), Mathf.Sin(radianAngle)).normalized;

            Vector3 shootPosition = transform.position;
            GameObject spell = Instantiate(VatThe, shootPosition, Quaternion.identity);

            Rigidbody2D spellRigidbody = spell.GetComponent<Rigidbody2D>();
            if (spellRigidbody != null)
            {
                spellRigidbody.velocity = direction * Force;
            }
            else
            {
                Debug.LogError("Rigidbody2D component is missing on the instantiated object.");
            }

            spell.transform.rotation = Quaternion.Euler(new Vector3(0, 0, currentAngle));
        }
        
    }
    public void StopSkill()
    {
        StopCoroutine(ShootBurt());
        
    }
}
