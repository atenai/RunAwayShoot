using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaMission : MonoBehaviour
{
    [SerializeField] private Image[] mArea01MissionTexList = new Image[0];
    [SerializeField] private Image[] mArea02MissionTexList = new Image[0];
    [SerializeField] private Image[] mArea03MissionTexList = new Image[0];
    [SerializeField] private Image[] mArea04MissionTexList = new Image[0];
    [SerializeField] private Image[] mArea05MissionTexList = new Image[0];
    [SerializeField] private Image[] mArea06MissionTexList = new Image[0];


    enum AreaNums
    {
        Non = 0,

        Max
    }

    //1はじまり
    private int mNowAreaNum;

    [SerializeField]
    private struct Area
    {
        [SerializeField] private Image mTex;

        [SerializeField] private bool bSuccess;
    }

    [SerializeField] Area[] mAreaMissions;

    void Awake()
    {
        mNowAreaNum = 1;
    }

    public void setAreaNum(int _i)
    {
        mNowAreaNum = _i;
    }
}
