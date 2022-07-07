using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneNextResult : MonoBehaviour
{
    bool debugGoal;

    Text GOAL_text;
    bool b_GOAL;
    float ResultTime;

    //サウンド
    public AudioClip GOALSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();

        //Textコンポーネント取得
        GOAL_text = GameObject.Find("TextGOAL").GetComponent<Text>();
        GOAL_text.text = "";

        b_GOAL = false;
        ResultTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(b_GOAL == true)
        {
            //Debug.Log("ゴール当たっているよ");
            ResultTime -= Time.deltaTime;
        }

        //　制限時間が0秒以下なら何もしない
        if (ResultTime <= -0.5f)
        {
            //リザルトへ
            SceneManager.LoadScene("Result");
            //Debug.Log("制限時間終了");
            Debug.Log("リザルト画面へシーン遷移！！");
            //return;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")   //敵の視界から離れたか障害物がある場合
        {
            GOAL_text.text = "GOAL";

            if (b_GOAL == false)
            {
                //SE再生
                //音(GOALSound)を鳴らす
                audioSource.PlayOneShot(GOALSound);
                Score.AddScore(3);//スコアに+10000加算
                b_GOAL = true;
            }
        }
    }

}
