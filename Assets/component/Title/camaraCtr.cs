using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraCtr : MonoBehaviour
{
    [SerializeField] MovieCtr moviectr;
    //MpvieCtr内の関数取得用
    bool videoFlag = false;
    //カメラ位置
    private Transform camera_transform;
    [SerializeField] float cnt;
    private bool inputFlag = false;

    void Awake()
    {
        camera_transform = this.gameObject.transform;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            inputFlag = true;
        }

        if (inputFlag == true)
        {
            //MovieCtr.cs関数取得
            // videoFlag = moviectr.GetvideoFlag();
            //動画終了したら
            //if (videoFlag)
            camera_transform.Translate(0.0f, 0.0f, cnt);
        }
    }
}
