using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area1Enemy7 : MonoBehaviour
{
    float f_EnemyHp;
    EnemyMove EnemyMove;

    void Awake()
    {
        EnemyMove = this.GetComponent<EnemyMove>();
    }

    void Update()
    {
        f_EnemyHp = EnemyMove.GetEnemyHP();
        if (f_EnemyHp <= 0.0f)
        {
            //Debug.Log("Enemy7のHPは0だよ！");
            Director.EnemyDestroy7();
        }
    }
}
