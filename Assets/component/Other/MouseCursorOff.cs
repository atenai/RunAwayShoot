using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //マウスカーソルを消す
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
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
