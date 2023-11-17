using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNext : MonoBehaviour
{

    [SerializeField] float SceneNextTimer;

    bool b_Start = false;

    //サウンド
    public AudioClip StartSound;
    AudioSource audioSource;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();

        b_Start = false;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            //SE再生
            //音(GOALSound)を鳴らす
            audioSource.PlayOneShot(StartSound);

            b_Start = true;
        }

        if (b_Start == true)
        {
            SceneNextTimer = SceneNextTimer - Time.deltaTime;
            if (SceneNextTimer <= 0.0f)
            {

                //ステージ１シーンへ
                SceneManager.LoadScene("Stage1");
            }
        }
    }
}
