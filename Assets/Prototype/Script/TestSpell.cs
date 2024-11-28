using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour
{
    public GameObject VatThe;
    public float Force = 10.0f;
    public bool CanShoot;

    private Vector2 lookDirection = new Vector2(1, 0);
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        CanShoot = true;
    }
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - (Vector2)transform.position;
        direction.Normalize();

        lookDirection = direction;

        // Calculate the angle without considering player flip
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (transform.localScale.x < 0)
        {
            angle = 180f - angle;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (mousePosition.x < transform.position.x)
        {
            spriteRenderer.flipY = true;
            spriteRenderer.flipX = true; // Flip the gun horizontally when the player flips
        }
        else
        {
            spriteRenderer.flipY = false;
            spriteRenderer.flipX = false; // Ensure the gun sprite is not flipped horizontally
        }

        if (Input.GetMouseButtonDown(0) && CanShoot == true)
        {
            Audio.Instance.PlaySFX("Shoot");
            CameraShake.instance.ShakeCameraShoot();

            Vector3 Vitriban = transform.position + new Vector3(0, 0, 0);

            // Instantiate đối tượng từ VatThe tại vị trí đã tính toán
            GameObject spell = Instantiate(VatThe, Vitriban, Quaternion.identity);

            // Tính toán hướng của đạn dựa trên vị trí chuột so với vị trí của player
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 gundirection = (mousePos - (Vector2)transform.position).normalized;

            // Lấy component Rigidbody2D của đối tượng mới và gán vận tốc cho nó
            Rigidbody2D spellRigidbody = spell.GetComponent<Rigidbody2D>();
            if (spellRigidbody != null)
            {
                // Ensure the gun's direction is used for velocity calculation
                spellRigidbody.velocity = gundirection * Force;
            }
            else
            {
                Debug.LogError("Rigidbody2D component is missing on the instantiated object.");
            }

            // Tính góc quay của đối tượng mới
            float Gunangle = Mathf.Atan2(gundirection.y, gundirection.x) * Mathf.Rad2Deg;

            // Adjust the angle if the player is flipped horizontally
            if (transform.localScale.x < 0)
            {
                Gunangle = 180f - Gunangle;
            }

            spell.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Gunangle));
          
        }
    }




}
