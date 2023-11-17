using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorOff : MonoBehaviour
{
    void Start()
    {
        //マウスカーソルを消す
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Escapeキーでマウスカーソルを出す
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.None;

        }
    }
}
