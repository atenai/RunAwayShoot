using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TitleScript : MonoBehaviour
{
    GameObject Right;
    GameObject Left;
    //VideoClip VideoClip;
    GameObject Video;
    VideoPlayer VideoPlayer;

    void Awake()
    {
        Right = GameObject.Find("Right");//右カーテンオブジェクトを取得
        Left = GameObject.Find("Left");//左カーテンオブジェクトを取得
        Video = GameObject.Find("Video Player");
        VideoPlayer = Video.GetComponent<VideoPlayer>();
    }

    void Start()
    {

    }

    void Update()
    {
        //// transformを取得
        //Transform RightTransform = Right.transform;
        //Transform LeftTransform = Left.transform;

        //// 右カーテン座標を取得
        //Vector3 Rightpos = RightTransform.position;
        //if (Rightpos.x < 20)
        //{
        //    Rightpos.x += 0.1f;    // x座標へ0.1加算
        //    RightTransform.position = Rightpos;  // 座標を設定
        //}

        //// 左カーテン座標を取得
        //Vector3 Leftpos = LeftTransform.position;
        //if (Leftpos.x > -20)
        //{
        //    Leftpos.x -= 0.1f;    // x座標へ-0.1加算
        //    LeftTransform.position = Leftpos;  // 座標を設定
        //}

        //if (Rightpos.x >= 20 && Leftpos.x <= -20)
        //{

        //}

        VideoPlayer.Play();
    }
}
