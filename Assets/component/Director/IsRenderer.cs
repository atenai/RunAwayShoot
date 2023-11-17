using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsRenderer : MonoBehaviour
{
    //カメラオブジェクト取得
    [SerializeField] private GameObject movieCamera1;

    //カメラについているタグ名
    private const string CAMERA_TAG_NAME = "MovieCamera1";

    //カメラに表示されているか
    public static bool isRendered = false;

    //プレイヤーが触れているか
    public bool isPlayer = false;

    [SerializeField] private GameObject plane;
    private InCamera script;

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

    //カメラに写っている間に呼ばれる
    /* private void OnWillRenderObject()
     {
         //カメラに映った時だけisRenderedを有効に
         if (Camera.current.tag == CAMERA_TAG_NAME)
         {

             isRendered = true;
         }
     }*/

    public static bool GetIsRendered()
    {
        return isRendered;
    }
}
