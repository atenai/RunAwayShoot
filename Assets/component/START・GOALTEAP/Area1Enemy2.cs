using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area1Enemy2 : MonoBehaviour
{
    float f_EnemyHp;
    EnemyMove EnemyMove;

    void Awake()
    {
        EnemyMove = this.GetComponent<EnemyMove>();
    }

    // Update is called once per frame
    void Update()
    {
        f_EnemyHp = EnemyMove.GetEnemyHP();
        if (f_EnemyHp <= 0.0f)
        {
           // Debug.Log("Enemy2のHPは0だよ！");
            Director.EnemyDestroy2();
        }
    }
}
