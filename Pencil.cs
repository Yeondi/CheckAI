using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//enum RainbowColors
//{
//    public Color red = Color.red;
//    public Color orange = Color.clear;
//    public Color yellow = Color.yellow;
//    public Color green = Color.green;
//    public Color blue = Color.blue;
//    public Color navy = Color.clear;
//    public Color purple = Color.cyan;
//}

public class Pencil : MonoBehaviour
{
    [SerializeField]
    Texture2D texture;

    Toggle toggle;

    [SerializeField]
    Color color;

    public CursorMode cursorMode;
    Vector2 hotspot = Vector2.zero;

    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    void Update()
    {
        if(toggle.isOn)
        {
            Cursor.SetCursor(texture, hotspot, cursorMode);
        }
    }

}
