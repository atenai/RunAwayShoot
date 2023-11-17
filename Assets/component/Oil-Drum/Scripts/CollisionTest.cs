//コリジョンテストオブジェクトスクリプト
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    void Update()
    {
        //移動
        transform.Translate(0.01f, 0, 0);
    }
}
