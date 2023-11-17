using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCamera : MonoBehaviour
{
    [SerializeField] private Director director;

    public static bool isStay = false;//プレイヤーが滞在してるか

    void Awake()
    {
        //キャンバスオブジェクト取得
        GameObject gameObject = GameObject.Find("Canvas");
        director = director.GetComponent<Director>();
    }

    void OnTriggerEnter(Collider other)
    {
        //プレイヤーが範囲にいたら
        if (other.gameObject.tag == "Player")
        {
            isStay = true;
            Debug.Log("カメラに当たりました");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isStay = false;
        }
    }

    public static bool GetisStay()
    {
        return isStay;
    }

}
