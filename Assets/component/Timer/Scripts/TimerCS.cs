using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimerCS : MonoBehaviour
{
    //　トータル制限時間
    private float totalTime;
    //　制限時間（分）
    [SerializeField]
    private int minute;
    //　制限時間（秒）
    [SerializeField]
    private float seconds;
    //　前回Update時の秒数
    private float oldSeconds;
    //表示するテキストデータ
    private Text timerText;

    Text TimeOver_text;
    bool b_Result;

    //サウンド
    public AudioClip TimeOverSound;
    AudioSource audioSource;

    void Start()
    {
        totalTime = minute * 60 + seconds;
        oldSeconds = 0f;
        timerText = GetComponentInChildren<Text>();

        //Textコンポーネント取得
        TimeOver_text = GameObject.Find("TimeOver").GetComponent<Text>();
        TimeOver_text.text = "";

        b_Result = false;

        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //　制限時間が0秒以下なら何もしない
        if (totalTime <= -0.5f)
        {
            //リザルトへ
            SceneManager.LoadScene("Result");
            //Debug.Log("制限時間終了");
            Debug.Log("リザルト画面へシーン遷移！！");
            //return;
        }
        //　一旦トータルの制限時間を計測；
        totalTime = minute * 60 + seconds;
        totalTime -= Time.deltaTime;
        

        //　再設定
        minute = (int)totalTime / 60;
        seconds = totalTime - minute * 60;

        //　タイマー表示用UIテキストに時間を表示する
        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
        //　制限時間以下になったらコンソールに『制限時間終了』という文字列を表示する
        if (totalTime <= 0.0f)
        {
           
            TimeOver_text.text = "TimeOver";   

            if (b_Result == false)
            {
                //SE再生
                //音(GOALSound)を鳴らす
                audioSource.PlayOneShot(TimeOverSound);
                Score.AddScore(5);//タイムオーバーになったらスコアを-3000にする//柏原
                b_Result = true;
            }
           

        }
    }


    public int GetMinute()
    {
        return minute;
    }
}
