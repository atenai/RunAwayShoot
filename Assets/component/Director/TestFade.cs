using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestFade : MonoBehaviour
{
    //テキストのフェードイン
    //[SerializeField] private float degreeInTime = 0.0f;
    // private float currentTime = 0.0f;　//時間計測
    public float fadeSpeed = 0.002f;　//フェードインのスピード
    private Color textColor;　　//テキストのカラー変数

    //UIテキストを格納
    public GameObject degree; //称号

    bool b_Fade = false;


    // Use this for initialization
    void Start()
    {
        //称号のカラーを取得してアルファを０に初期化
        textColor = this.degree.GetComponent<Text>().color;
        textColor.a = 0;
        this.degree.GetComponent<Text>().color = textColor;
    }

    // Update is called once per frame
    void Update()
    {

        // this.degree.GetComponent<Text>().text = "Test"; //称号をテキストへ表示　degreeNameは表示させる文字列

        //degreeInTime秒経ったらFadeInを呼ぶ
        // Invoke("FadeIn", degreeInTime);

        //または以下のように呼ぶか
        //currentTime += Time.deltaTime;                                  
        // if (degreeInTime < currentTime)
        // {
        //     FadeIn();
        // }

        if (Input.anyKeyDown)
        {
            b_Fade = true;
        }

            if (b_Fade == true)
        {
            FadeIn();
        }

    }

    void FadeIn()
    {
        if (textColor.a <= 1)
        {
            textColor.a += fadeSpeed;　//アルファ値を徐々に＋する
            this.degree.GetComponent<Text>().color = textColor;　//テキストへ反映させる
        }

    }
}
