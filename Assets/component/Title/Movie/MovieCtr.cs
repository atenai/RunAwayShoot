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

    
    private void Awake()
    {   
        // videoPlayeコンポーネントの追加
        var videoPlayer = screen.AddComponent<VideoPlayer>();
        // 動画ソースの設定
        videoPlayer.source = VideoSource.VideoClip; 
        videoPlayer.clip = videoClip;
        b_Video = false;
    }

    // Update is called once per frame
    void Update()
    {

        var videoPlayer = GetComponent<VideoPlayer>();
        ////rightUp取得(ライトがついてるか)
        //lightUp = lightctr.GetlightUp();
        ////ライトが付いたら
        //if (lightUp)
        //{
        //    if (b_Video == false)
        //    {
                videoPlayer.Play(); // 動画を再生する。
               
          //  }
            //フラグ抜けだすよう
            //b_Video = true;

       // }

        
        //動画が終了したら
        /*if ((ulong)videoPlayer.frame == videoPlayer.frameCount - 5)
        {
            //時間経過初期化
            lightctr.timeElapsed = 0.0f;
            lightctr.timeUp = false;
            lightctr.timeStart = true;
            lightctr.lightUp = false;
            //暗転開始
            lightctr.lightOff = true;
            //カメラ接近
            //videoFlag = true;
        }*/
    }
    public bool GetvideoFlag()
    {
        return videoFlag;
    }
}