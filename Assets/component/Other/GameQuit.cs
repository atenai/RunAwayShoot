using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
