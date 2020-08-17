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
            if (targetTime < currentTime) {
                deg = 0;
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
        Debug.Log (deg);
        float hankei = 2f; //弾オブジェクトを配置する円の半径
        float BulletInterval = 30f; //弾を生成する角度
        currentTime = 0;　 //タイマーを初期化
        while (deg <= 360 - BulletInterval) {
            //ラジアン生成
            var rad = deg * Mathf.Deg2Rad;
            //ラジアンを用いて、sinθとcosθを求める
            var sin = Mathf.Sin (rad);
            var cos = Mathf.Cos (rad);
            //弾オブジェクトを配置する座標を求める
            var pos = this.gameObject.transform.position + new Vector3 (cos * hankei, sin * hankei, 0);
            //弾prefabを生成する
            var bullet = Instantiate (EnemyBullet);
            //求めた円周上の座標に置く
            bullet.transform.position = pos;
            //発射準備
            var bulletScript = bullet.GetComponent<MediumEnemyBulletControll> ();
            list.Add (bulletScript);
            //次の角度へ
            deg += BulletInterval;
        }
        foreach (var bullet in list) {
            bullet.shot ();
        }
    }
}