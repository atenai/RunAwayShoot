using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STARTTEAP2 : MonoBehaviour
{
    //Director.cs呼び出し
    GameObject gameobject_director;

    Text MissionSuccess_text;

    void Awake()
    {
        //キャンバスオブジェクト取得
        gameobject_director = GameObject.Find("Canvas");

        //Textコンポーネント取得
        MissionSuccess_text = GameObject.Find("Mission Success").GetComponent<Text>();
    }

    void OnTriggerEnter(Collider other)
    {
        //プレイヤーがあたったら
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

            gameobject_director.GetComponent<Director>().area_Num = 2;//エリアをプラス１する
            Debug.Log("=2");

            MissionSuccess_text.text = "";
            //テキストカラー初期化
            MissionSuccess_text.color = new Color(255.0f, 0.0f, 0.0f);
        }
    }
}
