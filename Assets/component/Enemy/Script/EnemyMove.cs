using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float mSpeed = 2.0f;               //移動速度
    [SerializeField] private float mRotationSpeed = 1.0f;       //回転速度
    [SerializeField] private float mPosrange = 10f;             //
    [SerializeField] private float mHP;                         //HP
    [SerializeField] private float mMaxHP = 100;                //MaxHP
    private Vector3 mTargetPos;                                 //ターゲットポジション
    public GameObject Player;                                   //プレイヤーオブジェを格納する変数
    public float mDistancetoTarget;                             //ターゲット(巡回ポイント)との距離
    public float mDistancetoPlayer;                             //ターゲット(プレイヤーポイント)との距離

    private SphereCollider SearchArea;                          //視界コライダー
    [SerializeField] private float mSearchAngle = 50f;          //視界角度
    private int mSetMode;
    private bool mIs_Obstacle;                                  //プレイヤーとの間に障害物はあるか？
    //-----------------------------------------------------------------------------------------------------------------------------
    [SerializeField] public GameObject[] points;                //巡回地点オブジェクトを格納する配列
    private int mdestPoint = 0;                                 //巡回地点のオブジェクト数（初期値=0）
                                                                //※巡回ポイントの使い方
                                                                //①UnityのInspectorで巡回させたいポイントの数を設定
                                                                //②Create→Create Empty(空オブジェ)をポイント分作る
                                                                //③空オブジェのポジションを設定
                                                                //④巡回させたいルート順でpoints配列にぶち込む
                                                                //以上
                                                                //-----------------------------------------------------------------------------------------------------------------------------
    public float mDistancetoVoice;
    //-----------------------------------------------------------------------------------------------------------------------------

    private GameObject HPUI;                                    //　HP表示用UI

    private Slider HPSlider;                                    //　HP表示用スライダー
    //-----------------------------------------------------------------------------------------------------------------------------

    private GameObject Direction;                                //方向オブジェクトを格納する変数
    private EnemyAttack S_enemyAttack;                           //攻撃スクリプトを格納する変数
    private GameObject Direction2;
    private EnemyAttack S_enemyAttack2;
    public Vector3 BeDamaged_PlayerPos;

    // private GameObject gameobject_director;//ディレクター呼び出し
    // private Director director;
    public GameObject OCanvas;
    public GameObject TestObj;

    public GameObject ExplosionParticle;
    public GameObject ExplosionParticle2;
    private bool IsDestroy;
    private int Cnt;
    private int StayCnt = 0;

    public EnemySoundList EnemySound;

    //サウンド
    public AudioClip DamegeSound;
    AudioSource audioSource;

    void Awake()
    {
        //プレイヤーオブジェクトを格納
        Player = GameObject.Find("body");
        //行動パターン初期値をMoveに設定
        mSetMode = 1;
        //子オブジェクトのスフィアを格納
        SearchArea = this.gameObject.transform.Find("SearchArea").gameObject.GetComponent<SphereCollider>();
        //障害物判定初期値をfalse(なし)に設定
        mIs_Obstacle = false;
        // 次の巡回地点の処理を実行
        GotoNextPoint();
        //HPを設定
        mMaxHP = InitializeData.InitializeDataList.InitializeEnemyData.getHP();
        mHP = InitializeData.InitializeDataList.InitializeEnemyData.getHP();
        //HPスライダーを格納
        HPUI = this.gameObject.transform.Find("HPUI").gameObject;
        HPSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
        HPSlider.value = mHP / mMaxHP;

        //方向オブジェクトと攻撃スクリプトを格納
        Direction = this.gameObject.transform.Find("Direction").gameObject;
        S_enemyAttack = Direction.gameObject.GetComponent<EnemyAttack>();
        Direction2 = this.gameObject.transform.Find("Direction2").gameObject;
        S_enemyAttack2 = Direction2.gameObject.GetComponent<EnemyAttack>();

        OCanvas = GameObject.Find("Canvas").gameObject;

        this.gameObject.layer = LayerMask.NameToLayer("PlayerRayMask");
        IsDestroy = false;
        Cnt = 0;

        EnemySound = this.gameObject.transform.GetComponent<EnemySoundList>();

        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    private int WalkCnt = 0;

    void Update()
    {
        if (mSetMode == 1)
        {
            Move();
            StayCnt = 0;
        }
        if (mSetMode == 2)
        {
            Chase();
            StayCnt = 0;
        }
        if (mSetMode == 3)
        {
            Attack();
            StayCnt = 0;
        }
        if (mSetMode == 4)
        {
            BeDamaged();
        }
        if (mHP <= 0)
        {
            mSetMode = 0;
            DestroyPhase();
        }

        if (WalkCnt % 30 == 0 && (mSetMode == 1 || mSetMode == 2))
        {
            EnemySound.EnemyWalkSound();
        }
        WalkCnt++;
    }

    //-------------------------------------------------------------------------------------
    // 次の巡回地点を設定する処理
    //-------------------------------------------------------------------------------------
    void GotoNextPoint()
    {
        // 巡回地点が設定されていなければ
        if (points.Length == 0)
            // 処理を返します
            return;
        // 現在選択されている配列の座標を巡回地点の座標に代入
        mTargetPos = points[mdestPoint].transform.position;
        // 配列の中から次の巡回地点を選択（必要に応じて繰り返し）
        mdestPoint = (mdestPoint + 1) % points.Length;
    }

    //-------------------------------------------------------------------------------------
    //Ray関数
    //-------------------------------------------------------------------------------------
    void Ray()
    {
        RaycastHit Hit;
        // ターゲットオブジェクトとの差分を求め
        Vector3 Temp = Player.transform.position - this.transform.position;
        // 正規化して方向ベクトルを求める
        Vector3 Normal = Temp.normalized;
        //ヒットしたオブジェクト情報を取得
        if (Physics.Linecast(this.gameObject.transform.position + Vector3.up, Player.transform.position + Vector3.up, out Hit))
        {
            //レイを可視化
            //(デバッグ用)敵位置からプレイヤーまで線を飛ばす
            Debug.DrawLine(transform.position + Vector3.up, Player.transform.position + Vector3.up, Color.blue);

            if (Hit.transform.gameObject.name == "body")//bodyかPlayerに設定すれば反応する多分？
            {
                mIs_Obstacle = false;
            }
            else
            {
                mIs_Obstacle = true;
            }
        }
    }

    //-------------------------------------------------------------------------------------
    //移動関数
    //-------------------------------------------------------------------------------------
    void Move()
    {
        Quaternion targetRotation = Quaternion.LookRotation(mTargetPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * mRotationSpeed);
        transform.Translate(Vector3.forward * mSpeed * Time.deltaTime);

        mDistancetoTarget = Vector3.SqrMagnitude(transform.position - mTargetPos);
        //Debug.Log("Move");

        // エージェントが現在の巡回地点に到達したら
        if (mDistancetoTarget < 0.5f)
        {
            // 次の巡回地点を設定する処理を実行
            GotoNextPoint();
        }

    }

    //-------------------------------------------------------------------------------------
    //追尾関数
    //-------------------------------------------------------------------------------------
    void Chase()
    {
        Quaternion PlayerRotation = Quaternion.LookRotation(Player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, PlayerRotation, Time.deltaTime * mRotationSpeed * 10f);
        transform.Translate(Vector3.forward * mSpeed * 3f * Time.deltaTime);
        //Debug.Log("Chase");
        //ここにディレクターのエリア２をtrueにする
        // Debug.Log("敵に見つかった！！");//柏原
        Director.EnemyFound();//柏原
    }

    //-------------------------------------------------------------------------------------
    //攻撃関数
    private int AttackCnt = 0;
    //-------------------------------------------------------------------------------------
    void Attack()
    {
        Quaternion targetRotation = Quaternion.LookRotation(Player.gameObject.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * mRotationSpeed);
        //攻撃関数呼び出し
        S_enemyAttack.Shotting();
        S_enemyAttack2.Shotting();
        if (AttackCnt % 30 == 0)
        {
            EnemySound.EnemyShotSound();
        }
        AttackCnt++;
        //Debug.Log("Attack");
    }


    //-------------------------------------------------------------------------------------
    //被ダメージ
    //-------------------------------------------------------------------------------------
    private void BeDamaged()
    {
        if (StayCnt == 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(BeDamaged_PlayerPos - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * mRotationSpeed);
            transform.Translate(Vector3.forward * (mSpeed * 1.5f) * Time.deltaTime);

            mDistancetoTarget = Vector3.SqrMagnitude(transform.position - BeDamaged_PlayerPos);
        }

        //Debug.Log("Move");

        // エージェントが現在の巡回地点に到達したら
        if (mDistancetoTarget < 0.5f)
        {
            StayCnt++;
            if (StayCnt >= 90)
            {
                // 次の巡回地点を設定する処理を実行
                mSetMode = 1;
                StayCnt = 0;
            }
        }
    }

    private void DestroyPhase()
    {
        if (mHP <= 0)
        {
            IsDestroy = true;
        }
        if (IsDestroy == true)
        {
            if (Cnt == 0)
            {
                GameObject obj1;
                obj1 = Instantiate(ExplosionParticle, new Vector3(this.transform.position.x - 2.5f, this.transform.position.y + 0.5f, this.transform.position.z), this.transform.rotation);
                Destroy(obj1, 1f);
            }
            if (Cnt == 20)
            {
                GameObject obj2;
                obj2 = Instantiate(ExplosionParticle, new Vector3(this.transform.position.x + 2.5f, this.transform.position.y + 5f, this.transform.position.z), this.transform.rotation);
                Destroy(obj2, 1f);
            }
            if (Cnt == 40)
            {
                GameObject obj3;
                obj3 = Instantiate(ExplosionParticle, new Vector3(this.transform.position.x, this.transform.position.y + 3f, this.transform.position.z), this.transform.rotation);
                Destroy(obj3, 3f);

                Destroy(this.gameObject.gameObject);
            }
            Cnt++;

        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.name == "body")
        {
            //　主人公の方向
            var PlayerDirection = other.transform.position - transform.position;
            //　敵の前方からの主人公の方向
            var Angle = Vector3.Angle(transform.forward, PlayerDirection);

            Ray();

            //　サーチする角度内だったら発見
            if (Angle <= mSearchAngle && mIs_Obstacle == false && mHP > 0) //敵の視界に入ってかつ障害物がない場合
            {
                mSetMode = 2;
            }
            if (Angle <= mSearchAngle && mIs_Obstacle == true && mHP > 0)
            {
                mSetMode = 1;
            }
            //プレイヤーとの距離を計算
            mDistancetoPlayer = Vector3.SqrMagnitude(transform.position - Player.gameObject.transform.position);
            //Debug.Log("mDistancetoPlayer is :" + mDistancetoPlayer);
            //80以内で障害物がない場合は攻撃モードに移る
            if (Angle <= mSearchAngle && mDistancetoPlayer < 150.0f && mIs_Obstacle == false)
            {
                mSetMode = 3;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")   //敵の視界から離れたか障害物がある場合
        {
            mSetMode = 1;
        }
    }

    //エネミーがダメージを受けた際の処理
    private void OnCollisionEnter(Collision other)
    {
        if (mHP > 0)//HPが0以上だったら//柏原
        {
            if (other.gameObject.transform.tag == "PlayerBullet")
            {
                //SE再生
                //音(DamegeSound)を鳴らす
                audioSource.PlayOneShot(DamegeSound);

                mSetMode = 4;
                StayCnt = 0;
                mHP -= InitializeData.InitializeDataList.InitializePlayerData.getAssultDamege();
                HPSlider.value = mHP / mMaxHP;
                BeDamaged_PlayerPos = Player.gameObject.transform.position;
                Destroy(other.gameObject);
                if (mHP <= 0)
                {
                    //Destroy(this.gameObject);
                    Director.EnemyDestroy();//柏原
                    Score.AddScore(1);//エネミーを破壊したらスコアを+500する//柏原
                }
                Score.AddScore(0);//エネミーにダメージを与えたらスコアを+100する//柏原
                EnemySound.EnemyDamagedSound();//柏原
            }
        }
    }

    //#if UNITY_EDITOR
    //    //　サーチする角度表示
    //    private void OnDrawGizmos()
    //    {
    //        Handles.color = Color.red;
    //        Handles.DrawSolidArc(
    //            transform.position, 
    //            Vector3.up, 
    //            Quaternion.Euler(0f, -mSearchAngle, 0f) * transform.forward, 
    //            mSearchAngle * 2f, 
    //            SearchArea.radius);
    //    }
    //#endif


    public float GetEnemyHP()
    {
        return mHP;
    }

    public void ReceiveDamage(int Damage)
    {
        mHP -= Damage;
        HPSlider.value = mHP / mMaxHP;
        if (mHP <= 0)
        {
            //Destroy(this.gameObject);
            //Debug.Log("爆破デストロイ");
            Director.EnemyDestroy();//柏原//爆破によるデストロイとバレットによるデストロイを同時にしてしまった際に重複してよびだされてしまう。
            Score.AddScore(1);//エネミーを破壊したらスコアを+500する//柏原
            Director.EnemyDrumsDestroy();
        }
    }
}
