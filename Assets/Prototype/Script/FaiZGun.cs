using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaiZGun : MonoBehaviour
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
            // Trò chơi đang bị dừng, không xử lý input hoặc bắn
            return;
        }

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - (Vector2)transform.position;
        direction.Normalize();

        lookDirection = direction;

        // Tính góc mà không xét đến việc player bị lật
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (transform.localScale.x < 0)
        {
            angle = 180f - angle;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (mousePosition.x < transform.position.x)
        {
            spriteRenderer.flipY = true;
            spriteRenderer.flipX = true; // Lật ngang súng khi player bị lật
        }
        else
        {
            spriteRenderer.flipY = false;
            spriteRenderer.flipX = false; // Đảm bảo sprite của súng không bị lật ngang
        }

        if (Input.GetMouseButtonDown(0) && CanShoot)
        {
            // Logic bắn không thay đổi
            Audio.Instance.PlaySFX("Shoot2");
            CameraShake.instance.ShakeCameraShoot();

            Vector3 Vitriban = transform.position + new Vector3(0, 0.093f, 0);
            GameObject spell = Instantiate(VatThe, Vitriban, Quaternion.identity);

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 gundirection = (mousePos - (Vector2)transform.position).normalized;

            Rigidbody2D spellRigidbody = spell.GetComponent<Rigidbody2D>();
            if (spellRigidbody != null)
            {
                spellRigidbody.velocity = gundirection * Force;
            }
            else
            {
                Debug.LogError("Rigidbody2D component is missing on the instantiated object.");
            }

            float Gunangle = Mathf.Atan2(gundirection.y, gundirection.x) * Mathf.Rad2Deg;

            if (transform.localScale.x < 0)
            {
                Gunangle = 180f - Gunangle;
            }

            spell.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Gunangle));
        }
    }
}
