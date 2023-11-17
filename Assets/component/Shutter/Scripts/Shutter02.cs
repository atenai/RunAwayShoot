using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Shutter02 : MonoBehaviour
{
    //扉の列挙型
    public enum SHUTTER_TYPE
    {
        LEFT = 0,   //左
        RIGHT,      //右
        MAX,        //最大数
    }

    //親オブジェクト
    private GameObject m_Parent;

    //子オブジェクト
    private Transform m_ShutterL;
    private Transform m_ShutterR;

    //プレイヤーオブジェクト
    private GameObject m_Player;

    //プレイヤーサイズ
    private Vector3 m_PlayerSize;

    //プレイヤーエリア用コライダー
    private BoxCollider m_PlayerCollider;


    //2点間の距離
    private float[] m_Distance = new float[(int)SHUTTER_TYPE.MAX];
    //オブジェクト座標
    private Vector3[] m_ShutterPos = new Vector3[(int)SHUTTER_TYPE.MAX];
    //オブジェクト内側のオフセット
    private float[] InsideOffset = new float[(int)SHUTTER_TYPE.MAX];
    //プレイヤー侵入可能エリア
    private Vector3[] PlayerAreaPass = new Vector3[(int)SHUTTER_TYPE.MAX];

    //移動量
    private float[] m_fMove = new float[(int)SHUTTER_TYPE.MAX];

    //扉と扉の真ん中
    private Vector3 m_Center;
    //到達するまでの時間（秒)
    [SerializeField]
    private int m_Second;

    //シャッター閉じたか
    private bool m_bShutout;
    private bool m_bShutterStart;
    /*デバッグ関係*/
    //　距離を表示するテキストUI
    [SerializeField]
    private Text distanceUI;

    ////ディレクター取得
    //private GameObject gamedirector;
    //private Director director;

    private float UpdateDiatance;
    void Start()
    {
        //動的にコライダーのオンオフを切り替える
        GetComponent<BoxCollider>().enabled = false;

        m_bShutout = false;
        m_bShutterStart = false;
        //親を探す
        m_Parent = GameObject.Find("Shutter");

        //シャッターの子オブジェクトを探す
        m_ShutterL = m_Parent.transform.Find("ShutterL");
        m_ShutterR = m_Parent.transform.Find("ShutterR");

        //プレイヤー探す
        m_Player = GameObject.Find("Player/body");

        m_PlayerCollider = GetComponent<BoxCollider>();

        //ディレクター取得
        //gamedirector = GameObject.Find("Canvas");
        //director = gamedirector.GetComponent<Director>();

        m_ShutterPos[(int)SHUTTER_TYPE.RIGHT] = m_ShutterR.transform.position;
        m_ShutterPos[(int)SHUTTER_TYPE.LEFT] = m_ShutterL.transform.position;

        m_ShutterL.transform.position = new Vector3(m_ShutterPos[(int)SHUTTER_TYPE.LEFT].x, m_ShutterPos[(int)SHUTTER_TYPE.RIGHT].y, m_ShutterPos[(int)SHUTTER_TYPE.RIGHT].z);

        //プレイヤーの幅取得
        m_PlayerSize = m_Player.GetComponent<Renderer>().bounds.size;
        //Debug.Log(m_PlayerSize);

        //コライダーサイズをプレイヤーに合わせる
        m_PlayerCollider.size = m_PlayerSize;

        //オブジェクトのサイズの半分（Rendererコンポーネントでオブジェクトの幅を取得している）
        InsideOffset[(int)SHUTTER_TYPE.RIGHT] = m_ShutterR.GetComponent<Renderer>().bounds.size.x * 0.5f;
        InsideOffset[(int)SHUTTER_TYPE.LEFT] = m_ShutterL.GetComponent<Renderer>().bounds.size.x * 0.5f;

        //センター座標
        m_Center = (m_ShutterPos[(int)SHUTTER_TYPE.LEFT] + m_ShutterPos[(int)SHUTTER_TYPE.RIGHT]) * 0.5f;

        //シャッターLとセンターの距離
        m_Distance[(int)SHUTTER_TYPE.LEFT] = Vector3.Distance(m_ShutterPos[(int)SHUTTER_TYPE.LEFT], m_Center) - InsideOffset[(int)SHUTTER_TYPE.LEFT];
        //シャッターRとセンターの距離
        m_Distance[(int)SHUTTER_TYPE.RIGHT] = Vector3.Distance(m_ShutterPos[(int)SHUTTER_TYPE.RIGHT], m_Center) - InsideOffset[(int)SHUTTER_TYPE.RIGHT];

        //プレイヤー侵入エリアの設定
        PlayerAreaPass[(int)SHUTTER_TYPE.LEFT] = m_Center - m_PlayerCollider.size * 0.5f;
        PlayerAreaPass[(int)SHUTTER_TYPE.RIGHT] = m_Center + m_PlayerCollider.size * 0.5f;

        //2点間を通るための速さ
        m_fMove[(int)SHUTTER_TYPE.LEFT] = m_Distance[(int)SHUTTER_TYPE.LEFT] / m_Second;
        m_fMove[(int)SHUTTER_TYPE.RIGHT] = m_Distance[(int)SHUTTER_TYPE.RIGHT] / m_Second;

    }

    void Update()
    {
        //プレイヤー侵入エリア内に入ったら、コライダーを発生させる
        if (m_ShutterR.transform.position.x - InsideOffset[(int)SHUTTER_TYPE.RIGHT] <= PlayerAreaPass[(int)SHUTTER_TYPE.RIGHT].x)
        {
            //動的にコライダーのオンオフを切り替える
            GetComponent<BoxCollider>().enabled = true;
            //閉じた
            m_bShutout = true;
            //Debug.Log("プレイヤーは通れません");
            //Debug.Log(GetComponent<BoxCollider>().enabled);
        }
        else
        {
            GetComponent<BoxCollider>().enabled = false;

        }

        //プレイヤー侵入エリア内に入ったら、コライダーを発生させる
        if (m_ShutterL.transform.position.x + InsideOffset[(int)SHUTTER_TYPE.LEFT] >= PlayerAreaPass[(int)SHUTTER_TYPE.LEFT].x)
        {
            //動的にコライダーのオンオフを切り替える
            GetComponent<BoxCollider>().enabled = true;
            m_bShutout = true;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = false;

        }

        //左シャッターの右側の座標X
        //m_RightOffset = m_ShutterLPos.x +
        /*----------------  距離デバッグテキスト表示 ------------------------------------------------------------------*/

        //UpdateDiatance = Vector3.Distance(m_ShutterR.transform.position, m_ShutterL.transform.position) - m_ColliderOffset ;
        //if (distanceUI != null)
        //{
        //    distanceUI.text = UpdateDiatance.ToString("0.00m");
        //}

        /*-------------------------------------------------------------------------------------------------------------*/
        //if(director.directors[3].IsArea)
        //{
        if (m_bShutterStart == true)
        {
            if (m_ShutterR.transform.position.x - InsideOffset[(int)SHUTTER_TYPE.RIGHT] >= m_Center.x)
            {
                m_ShutterR.transform.position -= m_ShutterR.transform.right * m_fMove[(int)SHUTTER_TYPE.RIGHT] * Time.deltaTime;
            }


            if (m_ShutterL.transform.position.x + InsideOffset[(int)SHUTTER_TYPE.LEFT] <= m_Center.x)
            {
                m_ShutterL.transform.position += m_ShutterL.transform.right * m_fMove[(int)SHUTTER_TYPE.LEFT] * Time.deltaTime;
            }

        }

    }

    //シャッター閉じる開始
    public void Shutter_Start()
    {
        m_bShutterStart = true;
    }

    //シャッター用タイマーの更新処理
    void TimerUpdate()
    {

    }

    public bool GetShutout()
    {
        return m_bShutout;
    }


    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("当たった!");
    }

}
