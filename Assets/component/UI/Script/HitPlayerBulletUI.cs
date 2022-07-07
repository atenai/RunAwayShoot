using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HitUI
{

    public class HitPlayerBulletUI : MonoBehaviour
    {
        static private float timer;


        void Awake()
        {
            timer = 0;
        }


        void OnGUI()
        {
            // タイマーを減算
            timer -= Time.deltaTime ;

            if (timer < 0)
                return;

            GetComponent<Image>().color = new Color(255, 255, 255, timer/3); //Imageのカラーを変更。Colorの引数は（ 赤, 緑, 青, 不透明度 ）の順で指定


        }

        static public void OnHitPlayerBullet()
        {
            timer = 1;
        }
    }
}