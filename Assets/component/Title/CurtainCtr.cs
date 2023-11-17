using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainCtr : MonoBehaviour
{
    [SerializeField] GameObject CurtainR;
    [SerializeField] GameObject CurtainL;
    // Update is called once per frame
    Vector3 vec3R;
    Vector3 vec3L;

   bool b_Start = false;

    //サウンド
    public AudioClip sound2;
    AudioSource audioSource;
    bool b_SE = false;

    private void Awake()
    {
        vec3L = new Vector3(-11.0f, 0.0f, -1.0f);
        vec3R = new Vector3(11.0f, 0.0f, -1.0f);

        b_Start = false;

        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        b_SE = false;
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            b_SE = true;

            if (b_SE == true && b_Start == false)
            {
                //音(sound2)を鳴らす
                audioSource.PlayOneShot(sound2);
            }
            b_Start = true;
        }

        if (b_Start == true)
        {
            

            if (vec3L.x > -20.0f)
            {
                vec3L.x -= 0.1f;
            }
            if (vec3R.x < 20.0f)
            {
                vec3R.x += 0.1f;
            }
            CurtainL.transform.position = vec3L;
            CurtainR.transform.position = vec3R;
        }
    }
}
