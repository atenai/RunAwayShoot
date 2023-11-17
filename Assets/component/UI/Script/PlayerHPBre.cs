using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBre : MonoBehaviour
{
    //Playerコンポーネント
    private player mPlayerCon;

    //HP表示に用いるオブジェクト
    [SerializeField]
    private Image mLifeUI;
    [SerializeField]
    private Image mRedGageUI;

    void Awake()
    {
        mPlayerCon = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();

        //バーの初期化
        mLifeUI.fillAmount = 1;
        mRedGageUI.fillAmount = 1;
    }

    void Update()
    {
        mLifeUI.fillAmount = mPlayerCon.getHP() / InitializeData.InitializeDataList.InitializePlayerData.getHP();
    }

}
