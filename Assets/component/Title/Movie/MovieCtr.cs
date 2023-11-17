using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
public class MovieCtr : MonoBehaviour
{
    [SerializeField] private VideoClip videoClip;
    [SerializeField] private GameObject screen;

    //LightCtr取得用
    bool lightUp;
    public LightCtr lightctr;

    //動画終わった？
    bool videoFlag = false;
    //動画始まったか
    bool b_Video = false;

    void Awake()
    {
        // videoPlayeコンポーネントの追加
        var videoPlayer = screen.AddComponent<VideoPlayer>();
        // 動画ソースの設定
        videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.clip = videoClip;
        b_Video = false;
    }

    void Update()
    {
        var videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.Play(); // 動画を再生する。
    }

    public bool GetvideoFlag()
    {
        return videoFlag;
    }
}