using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteSmokeCS : MonoBehaviour
{
    //参照するエネミーオブジェクト
    GameObject m_TargetEnemy;
    //参照するエネミースクリプト
    EnemyMove m_EnemyCS;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Debug.Log("敵に消火器爆発ダメージ");
            Score.AddScore(1);//消火器でダメージを与えた
            //相手を消す
            coll.gameObject.GetComponent<EnemyMove>().ReceiveDamage(60);


        }
    }
}
