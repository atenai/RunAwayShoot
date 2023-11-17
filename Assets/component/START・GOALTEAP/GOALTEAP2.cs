using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GOALTEAP2 : MonoBehaviour
{
    GameObject gameobject_director;//Director.cs呼び出し

    
    //Text direct_text;
    //Text content_text;

    private void Awake()
    {
        //キャンバスオブジェクト取得
        gameobject_director = GameObject.Find("Canvas");
    }
    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーがあたったら
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

            gameobject_director.GetComponent<Director>().b_FoundFalseGOAL = true;

            //direct_text.text = "";

            //content_text.text = "";

            

            gameobject_director.GetComponent<Director>().b_GOAL2 = true;
        }
    }
}
