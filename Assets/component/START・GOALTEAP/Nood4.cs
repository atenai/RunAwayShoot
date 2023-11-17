﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nood4 : MonoBehaviour
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

            gameobject_director.GetComponent<Director>().Addnood4();
        }
    }
}
