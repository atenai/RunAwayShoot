using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCS02 : MonoBehaviour
{
    //　トータル制限時間
    private float totalTime;
    //　制限時間（分）
    [SerializeField]
    private int minute;
    //　制限時間（秒）
    [SerializeField]
    private float seconds;
    //　前回Update時の秒数
    private float oldSeconds;

    //描画するスプライト
    public Sprite[] numimage;
    //数字の桁情報
    public List<int> number = new List<int>();

    void Start()
    {
        //トータルタイムの初期化
        totalTime = minute * 60 + seconds;
        oldSeconds = 0f;
    }

    void Update()
    {
        //　制限時間が0秒以下なら何もしない
        if (totalTime <= 0f)
        {
            return;
        }
        //　一旦トータルの制限時間を計測；
        totalTime = minute * 60 + seconds;
        totalTime -= Time.deltaTime;

        //　再設定
        minute = (int)totalTime / 60;
        seconds = totalTime - minute * 60;

        //制限時間以下になった時
        if (totalTime <= 0f)
        {
            Debug.Log("制限時間終了");
        }

        //1秒ごとに更新させるため
        if ((int)seconds != (int)oldSeconds)
        {

            Draw((int)seconds);
            //いままで表示されてたスコアオブジェクト削除
            var objs = GameObject.FindGameObjectsWithTag("ScoreImage");
            foreach (var obj in objs)
            {
                if (0 <= obj.name.LastIndexOf("Clone"))
                {
                    Destroy(obj);
                }
            }
        }
    }

    //数字の表示(関数で値渡し)
    void Draw(int score)
    {
        var digit = score;
        //要素数0には１桁目の値が格納
        number = new List<int>();
        while (digit != 0)
        {
            score = digit % 10;
            digit = digit / 10;
            number.Add(score);
        }

        //オブジェクトを探す
        GameObject.Find("ScoreImage").GetComponent<Image>().sprite = numimage[number[0]];

        //桁ごと処理をする
        for (int i = 1; i < number.Count; i++)
        {
            //複製
            RectTransform scoreimage = (RectTransform)Instantiate(GameObject.Find("ScoreImage")).transform;
            scoreimage.SetParent(this.transform, false);
            scoreimage.localPosition = new Vector2(
            scoreimage.localPosition.x - scoreimage.sizeDelta.x * i,
            scoreimage.localPosition.y);
            scoreimage.GetComponent<Image>().sprite = numimage[number[i]];
        }
    }
}
