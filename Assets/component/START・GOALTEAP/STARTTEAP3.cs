using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STARTTEAP3 : MonoBehaviour
{
    GameObject gameobject_director;//Director.cs呼び出し

    Text MissionSuccess_text;

    private void Awake()
    {
        //キャンバスオブジェクト取得
        gameobject_director = GameObject.Find("Canvas");

        //Textコンポーネント取得
        MissionSuccess_text = GameObject.Find("Mission Success").GetComponent<Text>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーがあたったら
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            //gameobject_director.GetComponent<Director>().area_flag = true;
            // gameobject_director.GetComponent<Director>().areaflag();
            gameobject_director.GetComponent<Director>().area_Num = 3;//エリアをプラス１する
            Debug.Log("=3");

            MissionSuccess_text.text = "";
            //テキストカラー初期化
            MissionSuccess_text.color = new Color(255.0f, 0.0f, 0.0f);

        }
    }
}
