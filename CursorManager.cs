using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMod = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero; // Å¸°Ù Æ÷ÀÎÆ®

    public bool needChange = false;

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMod);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMod);
    }

    private void LateUpdate()
    {
        if(needChange)
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMod);
        }
    }
}
