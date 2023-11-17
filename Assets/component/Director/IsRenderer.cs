using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsRenderer : MonoBehaviour
{
    //カメラオブジェクト取得
    [SerializeField] GameObject movieCamera1;

    //カメラについているタグ名
    const string CAMERA_TAG_NAME = "MovieCamera1";

    //カメラに表示されているか
    public static bool isRendered = false;

    //プレイヤーが触れているか
    public bool isPlayer = false;

    [SerializeField] GameObject plane;
    InCamera script;

    void Awake()
    {
        script = plane.GetComponent<InCamera>();
    }

    void Update()
    {
        isRendered = false;

        //プレイヤーが映ったら
        if (isPlayer)
        {
            //Debug.Log("撮影開始");
            movieCamera1.SetActive(true);
        }
        else
        {
            movieCamera1.SetActive(false);
        }
    }

    public static bool GetIsRendered()
    {
        return isRendered;
    }
}
