using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GOALTEAP1 : MonoBehaviour
{
    GameObject gameobject_director;//Director.cs呼び出し

    //Text Table1_text;
    //Text Table2_text;
    //Text Table3_text;
    //Text Table4_text;
    //Text Table5_text;
    //Text Table6_text;
    //Text Table7_text;
    //Text Table8_text;
    //Text MissionSuccess_text;

    private void Awake()
    {
        //キャンバスオブジェクト取得
        gameobject_director = GameObject.Find("Canvas");

        ////Textコンポーネント取得
        //Table1_text = GameObject.Find("Table1").GetComponent<Text>();
        

        ////Textコンポーネント取得
        //Table2_text = GameObject.Find("Table2").GetComponent<Text>();
        

        ////Textコンポーネント取得
        //Table3_text = GameObject.Find("Table3").GetComponent<Text>();
        

        ////Textコンポーネント取得
        //Table4_text = GameObject.Find("Table4").GetComponent<Text>();
        

        ////Textコンポーネント取得
        //Table5_text = GameObject.Find("Table5").GetComponent<Text>();
        

        ////Textコンポーネント取得
        //Table6_text = GameObject.Find("Table6").GetComponent<Text>();
        

        ////Textコンポーネント取得
        //Table7_text = GameObject.Find("Table7").GetComponent<Text>();
       

        ////Textコンポーネント取得
        //Table8_text = GameObject.Find("Table8").GetComponent<Text>();

        ////Textコンポーネント取得
        //MissionSuccess_text = GameObject.Find("Mission Success").GetComponent<Text>();
        

    }
    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーがあたったら
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

            gameobject_director.GetComponent<Director>().b_GOAL1 = true;


        }
    }
}
