using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //トータルスコア
    public static int score;

    //スコア加算リスト
    public enum AddScoreType
    {
        Add100,//0エネミーにダメージを与えた
        Add500,//1ドラム缶等で敵にダメージを与えた/敵を倒した
        Add3000,//2
        Add5000,//3ゴールに着いた
        take100,//4プレイヤーがダメージを受けた
        take3000,//5タイムオーバーになった
    };
    public static AddScoreType add_score_type;


    Text score_text;
    void Awake()
    {
        score = 0;//スコア初期化
        //Textコンポーネント取得
        score_text = this.GetComponent<Text>();
        //テキストの文字入力
        score_text.text = score + "";

    }

    void Update()
    {
        //テキストの文字入力
        score_text.text = score + "";
    }

    //スコア加算
    public static int AddScore(int num)
    {
        add_score_type = (AddScoreType)num;
        switch (add_score_type)
        {
            case AddScoreType.Add100://0:エネミーにダメージを与える
                score += 100;
                //Debug.Log("エネミーにダメージを与えたよ");
                break;
            case AddScoreType.Add500://1:ドラム缶・消火器でダメージを与えた/敵を倒した
                score += 500;
                //Debug.Log("エネミーを倒したよ/ドラム缶・消火器を使ってダメージを与えたよ");
                break;
            case AddScoreType.Add3000://2:
                score += 3000;
                break;
            case AddScoreType.Add5000://3:ゴールに着いた
                score += 5000;
                //Debug.Log("ゴールに着いたよ");
                break;
            case AddScoreType.take100://4:プレイヤーがダメージを受けた
                score -= 100;
                //Debug.Log("プレイヤーがダメージを受けたよ");
                break;
            case AddScoreType EnemyDamege://5:タイムオーバーになった
                score -= 3000;
                //Debug.Log("タイムオーバーになったよ");
                break;
        }
        return score;
    }

    public static int GetScore()
    {
        return score;
    }
}