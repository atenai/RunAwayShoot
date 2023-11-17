using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressAnyKey : MonoBehaviour
{
    bool b_Start = false;

    bool g_bPress = true;//タイトルテクスチャのON/OFFの変更をする
    int g_nCnt = 0;//タイトルのON/OFFの時間をカウントをする

    Text PressAnyKey_text;

    private float alfa = 0.0f;//テキスト・α値
    private const float max = 1.0f;
    private const float min = 0.0f;
    bool b_alfa = false;
    [SerializeField] private float plas_alfa;

    void Start()
    {
        b_Start = false;

        //Textコンポーネント取得
        PressAnyKey_text = GameObject.Find("PRESSANYKEY").GetComponent<Text>();

        //テキストカラー初期化
        PressAnyKey_text.color = new Color(255.0f, 255.0f, 255.0f, alfa);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            b_Start = true;
        }

        if (b_Start == false)
        {
            PressAnyKey_text.text = "Press Any Button";
        }
        else
        {
            PressAnyKey_text.text = "";
        }

        if (alfa >= max) b_alfa = true;
        if (alfa <= min) b_alfa = false;

        if (b_alfa)
        {
            alfa -= plas_alfa;
        }
        else
        {
            alfa += plas_alfa;
        }

        PressAnyKey_text.color = new Color(255.0f, 255.0f, 255.0f, alfa);
    }
}
