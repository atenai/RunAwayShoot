using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCamera : MonoBehaviour
{
    [SerializeField] private Director director;

    static public bool isStay = false;//プレイヤーが滞在してるか

    private void Awake()
    {
        //キャンバスオブジェクト取得
        GameObject gameObject = GameObject.Find("Canvas");
        director = director.GetComponent<Director>();
    }

    void Update()
    {
        ////ゴールに着いたら色変わる
        //if (director.isAchieve)
        //{
        //    GetComponent<Renderer>().material.color = Color.red;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーが範囲にいたら
        if (other.gameObject.tag == "Player")
        {
            isStay = true;
            Debug.Log("カメラに当たりました");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isStay = false;
        }
    }

    static public bool GetisStay()
    {
        return isStay;
    }

}
