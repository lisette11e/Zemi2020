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
    public float targetTime = 1.0f;
    public float currentTime = 0;
    public float deg = 0;
    public bool isMake = false;

    // Start is called before the first frame update

    void Start () { //マイキャラを探してもらう
        this.stMychara = GameObject.Find ("stMychara");
    }

    // Update is called once per frame
    void Update () {
        //キャラと敵の当たり判定
        Vector2 p1 = transform.position;
        Vector2 p2 = this.stMychara.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.2f;
        float r2 = 0.4f;
        if (d < r1 + r2) {
            //監督スクリプトにhpをへらしてもらう
            PlayerManager.Instance.DecreaseHp (25);

            //コンボリセット
            ScoreManager.Instance.resetCombo ();

            //マイキャラと衝突したら弾を消す
            Destroy (gameObject);
        }
        if (GameDirector.Instance.CurrentPhase == 2) {
            currentTime += Time.deltaTime;
            Debug.Log (currentTime);
            if (targetTime < currentTime) {
                isMake = false;
                shotBullet ();
            };
        }

    }

    //被弾処理
    public void DecreaseHp () {
        //被弾時にコンボ値を変更できるようにする
        Debug.Log (PlayerManager.Instance.CurrentPlayerAttack);
        EnemyMobMediumHp -= PlayerManager.Instance.CurrentPlayerAttack;
        if (EnemyMobMediumHp <= 0) {
            Destroy (gameObject);
            Instantiate (explosionPrefab, transform.position, Quaternion.identity);
            ScoreManager.Instance.AddScore (5000);
        }
    }

    public void shotBullet () {
        float hankei = 0.05f; //弾オブジェクトを配置する円の半径
        float BulletInterval = 30f; //弾を生成する角度
        currentTime = 0;　 //タイマーを初期化
        if (!isMake) {
            //角度からラジアン生成
            var rad = deg * Mathf.Deg2Rad;
            //ラジアンを用いて、sinとcosを求める
            var sin = Mathf.Sin (rad);
            var cos = Mathf.Cos (rad);
            //弾オブジェクトを配置する座標を生成
            var pos = this.gameObject.transform.position + new Vector3 (cos * hankei, sin * hankei, 0);
            //弾の作成
            var bullet = Instantiate (EnemyBullet);
            //求めた円周上の座標に置く
            bullet.transform.position = pos;
            //次の角度へ
            deg += BulletInterval;
            //次の計算結果が、360度よりも大きくなったら弾を作らないようにする
            if (deg > 360 - BulletInterval) isMake = true;
        }
    }
}