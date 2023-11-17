using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shutter : MonoBehaviour
{
    //相手のオブジェクト
    private GameObject m_Target;
    //2点間の距離
    private float m_Distance;
    //自身の座標
    private Vector3 m_Position;
    //対象となるオブジェクトの座標
    private Vector3 m_TargetPosition;

    //到達するまでの時間（秒)
    [SerializeField] private int m_Second;

    private float m_ColliderOffset;

    //移動量
    private float m_fMove;

    private bool m_bShutout;

    /*デバッグ関係*/
    //　距離を表示するテキストUI
    [SerializeField] private Text distanceUI;

    private float UpdateDiatance;

    void Start()
    {
        m_bShutout = false;

        m_Target = GameObject.Find("target2");
        m_Position = this.transform.position;
        m_TargetPosition = m_Target.transform.position;

        //壁との距離計算のためのオフセット値
        //Rendererコンポーネントでオブジェクトの幅を取得している
        m_ColliderOffset = (gameObject.GetComponent<Renderer>().bounds.size.x * 0.5f) + (m_Target.GetComponent<Renderer>().bounds.size.x * 0.5f);
        //2点間の初期地点の距離を測る
        m_Distance = Vector3.Distance(m_Position, m_TargetPosition) - m_ColliderOffset;

        //2点間を通るための速さ
        m_fMove = m_Distance / m_Second;
    }

    void Update()
    {
        /*----------------  距離デバッグテキスト表示 ------------------------------------------------------------------*/

        UpdateDiatance = Vector3.Distance(this.transform.position, m_Target.transform.position) - m_ColliderOffset;
        if (distanceUI != null)
        {
            distanceUI.text = UpdateDiatance.ToString("0.00m");
        }

        /*-------------------------------------------------------------------------------------------------------------*/


        //自身のオブジェクトの左側とターゲットオブジェクトの右側に到達するまで
        if (this.transform.position.x - (m_ColliderOffset * 0.5f) >= m_Target.transform.position.x + (m_ColliderOffset * 0.5f))
        {
            this.transform.position -= transform.right * m_fMove * Time.deltaTime;
        }
        else
        {
            //シャッターがしまったフラグをオン
            m_bShutout = true;
        }

    }

    public bool GetShutout()
    {
        return m_bShutout;
    }


}