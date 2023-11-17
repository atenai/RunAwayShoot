using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCtr : MonoBehaviour
{
    public float timeOut;
    [SerializeField]public float timeElapsed;

    public bool timeUp = false;
    public bool timeStart = false;
    //ライトが付き終わったか
    public bool lightUp = false;
    public bool lightOff = false;
    public float LIntensity;//明るさ

    bool b_Start = false;
    //どれくらいの速さで明るくなるか
    [SerializeField] public float lightUpSpeed;

    [SerializeField]float cnt;
    private void Awake()
    {
        LIntensity = this.GetComponent<Light>().intensity;
        b_Start = false;
        timeStart = true;
    }
    void Update()
    {
            //秒たったら
            if (timeUp)
            {
                //ライトが明転
                if (LIntensity < 1.0f)
                {
                    LIntensity += lightUpSpeed;
                }
                //動画開始
                if (LIntensity > 1.0f)
                {
                    lightUp = true;
                }
                this.GetComponent<Light>().intensity = LIntensity;

            }
            if(timeStart)
            {
                //時間経過
                if (timeElapsed >= timeOut)
                {
                    timeUp = true;
                }
                timeElapsed += Time.deltaTime;
            }
            if(lightOff)
            {
                //ライトが暗転
                if (LIntensity > -10.0f)
                {
                    LIntensity -= lightUpSpeed;
                }
                this.GetComponent<Light>().intensity = LIntensity;

            }
        
    }
    public bool GetlightUp()
    {
        return lightUp;
    }
}
