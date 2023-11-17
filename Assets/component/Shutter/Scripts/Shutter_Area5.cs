using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shutter_Area5 : MonoBehaviour
{
    GameObject ShutterOya;
    Transform ShutterCol;
    Transform ShutterX;

    float posy;
    bool b_pos;

    void Awake()
    {
        // 親オブジェクトを探す
        ShutterOya = GameObject.Find("ShutterArea5");

        // ShutterOyaの子オブジェクトの中から非アクティブなオブジェクトを探す
        ShutterCol = ShutterOya.transform.Find("ShutterCol");
        //小オブジェクトの表示をFalse
        ShutterCol.gameObject.SetActive(false);

        ShutterX = ShutterOya.transform.Find("ShutterX");

        b_pos = false;
        posy = 3.0f;
    }

    void Update()
    {
        if (b_pos == true)
        {
            if (posy >= -0.5f)
            {
                posy -= 0.01f;
            }
        }

        //ShutterX.gameObject.transform.position = new Vector3(-20.0f, posy, 5.0f);
        ShutterX.gameObject.transform.position = new Vector3(ShutterX.gameObject.transform.position.x, posy, ShutterX.gameObject.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {

        //プレイヤーがあたったら
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("トリガーに当たっているよ");
            //小オブジェクトの表示をtrue
            ShutterCol.gameObject.SetActive(true);//戻れなくする

            b_pos = true;//シャッターの閉鎖開始
        }
    }
}
