using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestFade : MonoBehaviour
{
    public float fadeSpeed = 0.002f;//フェードインのスピード
    Color textColor;//テキストのカラー変数

    //UIテキストを格納
    public GameObject degree; //称号

    bool b_Fade = false;

    void Start()
    {
        //称号のカラーを取得してアルファを０に初期化
        textColor = this.degree.GetComponent<Text>().color;
        textColor.a = 0;
        this.degree.GetComponent<Text>().color = textColor;
    }

    void Update()
    {
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
            textColor.a += fadeSpeed;//アルファ値を徐々に＋する
            this.degree.GetComponent<Text>().color = textColor;//テキストへ反映させる
        }
    }
}
