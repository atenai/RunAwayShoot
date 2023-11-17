using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCnt : MonoBehaviour
{

    static GameObject gameobject_director;//ディレクター呼び出し
    private Director director;
    Text enemycnt_text; 
    // Start is called before the first frame update
    void Awake()
    {
        //ディレクター取得
        gameobject_director = GameObject.Find("Canvas");
        director = gameobject_director.GetComponent<Director>();
        //Textコンポーネント取得
        enemycnt_text = this.GetComponent<Text>();
        //テキストの文字入力
        //enemycnt_text.text = director.enemyCnt + " / " + director.annihilationCnt;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //テキストの文字入力
       // enemycnt_text.text = director.enemyCnt + " / " + director.annihilationCnt;

    }
    public void Active()
    {
        this.gameObject.SetActive(true);
    }
    public void NonActive()
    {

        this.gameObject.SetActive(false);
    }
}
