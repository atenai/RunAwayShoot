using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCnt : MonoBehaviour
{
    //ディレクター呼び出し
    static GameObject gameobject_director;
    private Director director;
    Text enemycnt_text;

    void Awake()
    {
        //ディレクター取得
        gameobject_director = GameObject.Find("Canvas");
        director = gameobject_director.GetComponent<Director>();
        //Textコンポーネント取得
        enemycnt_text = this.GetComponent<Text>();

        this.gameObject.SetActive(false);
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
