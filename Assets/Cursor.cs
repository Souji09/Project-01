using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCursor : MonoBehaviour
{
    public Texture2D cursorTexture;  // Kéo hình ảnh con trỏ vào đây trong Inspector

    void Start()
    {
        // Tính toán vị trí hotspot (trung tâm của hình ảnh con trỏ)
        Vector2 hotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);

        // Đặt con trỏ mới với hotspot đã tính toán
        Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);

        // Đảm bảo con trỏ hiển thị
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

