using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollTape : MonoBehaviour
{
    GameObject gameobject_director;//Director.cs呼び出し

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

            gameobject_director.GetComponent<Director>().area_Num++;//エリアをプラス１する
            Debug.Log("+1");
        }
    }
}
