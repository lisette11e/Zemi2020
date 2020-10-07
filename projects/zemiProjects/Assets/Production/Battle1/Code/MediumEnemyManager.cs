using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyManager : MonoBehaviour {

    float fallspd; //落ちてくる速度を設定する子

    //敵ステータス宣言
    public int EnemyMobMediumHp = 1000;
    public int EnemyMobMediumAttack = 100;
    public int EnemyMobMediumEigenvalue = 5000;

    //必要なゲームオブジェクトの定義
    public GameObject EnemyBullet;
    GameObject stMychara;
    public GameObject explosionPrefab;

    //弾発射用のもの
    public float targetTime = 3.0f;
    public float currentTime = 0;
    public float deg = 0;
    public bool isMake = false;
    public List<MediumEnemyBulletControll> list = new List<MediumEnemyBulletControll> ();

    //クリア時流すアニメーション変数の定義
    TypefaceAnimator anim;

    // Start is called before the first frame update

    void Start () { //マイキャラを探してもらう
        this.stMychara = GameObject.Find ("stMychara");
        Random.InitState (System.DateTime.Now.Millisecond);

       

        

    }

    // Update is called once per frame
    void Update () {
        //ステージクリアの出現
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position; //座標を取得
        if (EnemyMobMediumHp < 1)
        {
            pos.y += -400f; //clearの出現
        }

        myTransform.position = pos; //座標を設定

        anim = this.gameObject.GetComponent<TypefaceAnimator>();
        //クリア時のアニメーションを流す
        if (EnemyMobMediumHp < 1)
        {
            anim.Play();
        }
        //キャラと敵の当たり判定
        Vector2 p1 = transform.position;
        Vector2 p2 = this.stMychara.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.2f;
        float r2 = 0.4f;
        if (d < r1 + r2) {
            //監督スクリプトにhpをへらしてもらう
            PlayerManager.Instance.DecreaseHp (EnemyMobMediumAttack);

            //コンボリセット
            ScoreManager.Instance.resetCombo ();

            //マイキャラと衝突したら弾を消す
            Destroy (gameObject);
        }
        if (GameDirector.Instance.CurrentPhase == 2) {
            currentTime += Time.deltaTime;
            if (targetTime < currentTime) {
                deg = 0;
                isMake = false;
                shotBullet ();
            };
        }
        
        
    }

    //被弾処理
    public void DecreaseHp () {
        int Combo = ScoreManager.Instance.CurrentCombo;
        //被弾時にコンボ値を変更できるようにする
        Debug.Log (PlayerManager.Instance.CurrentPlayerAttack);
        EnemyMobMediumHp -= PlayerManager.Instance.CurrentPlayerAttack;
        if (EnemyMobMediumHp <= 0) {
            Destroy (gameObject);
            Instantiate (explosionPrefab, transform.position, Quaternion.identity);
            double scrtmp = 5000 * (Combo + 1) * 0.01;
            int add = (int) scrtmp;
            ScoreManager.Instance.AddScore (add);
            
        }
    }

    /**********
    ランダム生成したときのアーカイブ。

        public void shotBullet () {
            int shotnum;
            int shotcnt;
            shotnum = Random.Range (1, 8);
            shotcnt = 0;
            while (shotnum > shotcnt) {
                // 弾を生成させる
                Instantiate (EnemyBullet, new Vector3 (-2.5f + 5 * Random.value, 6, 0), Quaternion.identity);
                shotcnt++;
            }
            // タイマーのリセット
            currentTime = 0f;
        }
    }
    **********/
    public void shotBullet () {
        Debug.Log (deg);
        float hankei = 2f; //弾オブジェクトを配置する円の半径
        float BulletInterval = 30f; //弾を生成する角度
        currentTime = 0;　 //タイマーを初期化
        while (deg <= 360 - BulletInterval) {
            GameObject clone = (GameObject) Instantiate (EnemyBullet, transform.position, Quaternion.identity);
            clone.GetComponent<MediumEnemyBulletControll> ().SetVelocity ((clone.GetComponent<MediumEnemyBulletControll> ().VelocitySetting (deg, 3) / 300));
            deg += BulletInterval;
        }
    }
}