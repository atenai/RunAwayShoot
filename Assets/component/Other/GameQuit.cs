using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuit : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    private void LateUpdate()
    {
        //Escapeキーでゲーム終了
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();//ゲーム終了
        }
    }

    void Quit()
    {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
                                      UnityEngine.Application.Quit();
#endif
    }
}
