using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCS : MonoBehaviour
{
    //参照するエネミーオブジェクト
    GameObject m_TargetEnemy;
    //参照するエネミースクリプト
    EnemyMove m_EnemyCS;

    void OnTriggerEnter(Collider coll)//弾とのあたり判定を取っている
    {
        if (coll.gameObject.tag == "Enemy")
        {
            //Debug.Log("敵にドラム缶爆発ダメージ");
            Score.AddScore(1);//ドラム缶でダメージを与えた
            //相手を消す
            coll.gameObject.GetComponent<EnemyMove>().ReceiveDamage(120);
        }
    }


}
