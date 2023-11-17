using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nood2 : MonoBehaviour
{
    //Director.cs呼び出し
    GameObject gameobject_director;

    void Awake()
    {
        //キャンバスオブジェクト取得
        gameobject_director = GameObject.Find("Canvas");
    }

    void OnTriggerEnter(Collider other)
    {
        //プレイヤーがあたったら
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

            gameobject_director.GetComponent<Director>().Addnood2();
        }
    }
}
