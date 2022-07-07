using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumCS : MonoBehaviour
{

    public GameObject explosionPrefab;   //爆発エフェクトのPrefab
    public GameObject ExplosionPlayer;
    public AudioClip Explosion_SE;
    private float SE_Endtime;


    // Start is called before the first frame update
    void Start()
    {
        SE_Endtime = Explosion_SE.length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //当たった瞬間
    void OnTriggerEnter(Collider coll)
    {
        // プレイヤーバレットに当たった場合
        if (coll.gameObject.transform.tag == "PlayerBullet")
        {
            //Debug.Log("ドラム缶爆発");
            // 爆発エフェクトを生成する	
            GameObject effect = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //SE再生
            GameObject SE= Instantiate(ExplosionPlayer, this.transform.position, Quaternion.identity);
            Destroy(SE, SE_Endtime);
            //1秒後に爆発
            Destroy(effect, 1.0f);
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}
