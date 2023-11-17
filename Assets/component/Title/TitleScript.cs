using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TitleScript : MonoBehaviour
{
    GameObject Right;
    GameObject Left;
    GameObject Video;
    VideoPlayer VideoPlayer;

    void Awake()
    {
        Right = GameObject.Find("Right");//右カーテンオブジェクトを取得
        Left = GameObject.Find("Left");//左カーテンオブジェクトを取得
        Video = GameObject.Find("Video Player");
        VideoPlayer = Video.GetComponent<VideoPlayer>();
    }

    void Update()
    {
        VideoPlayer.Play();
    }
}
