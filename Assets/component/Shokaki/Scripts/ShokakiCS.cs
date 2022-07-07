using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShokakiCS : MonoBehaviour
{
    //当たった時に発生するエフェクトのプレハブ
    public GameObject EffectPrefab;
    private Vector3 EffectPosition;
    public float EffectDestroyTime;
    public GameObject AirPlayer;
    public AudioClip Air_SE;
    private float SE_Endtime;

    // Start is called before the first frame update
    void Start()
    {
        SE_Endtime = Air_SE.length;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider coll)
    {
        // プレイヤーバレットに当たった場合
        if (coll.gameObject.transform.tag == "PlayerBullet")
        {
            //Debug.Log("消火器爆発");
            //爆発エフェクトを生成する	
            GameObject effect = Instantiate(EffectPrefab, this.gameObject.transform.position, Quaternion.identity);
            //SE再生
            GameObject SE = Instantiate(AirPlayer, this.transform.position, Quaternion.identity);
            Destroy(SE, SE_Endtime);
            //1秒後に爆発
            Destroy(effect, EffectDestroyTime);
            Destroy(coll.gameObject);
            Destroy(this.gameObject);
        }
    }
}
