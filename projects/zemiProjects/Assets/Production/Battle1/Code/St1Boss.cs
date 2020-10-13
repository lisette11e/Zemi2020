using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class St1Boss : MonoBehaviour {
    float fallspd; //落ちてくる速度を設定する子

    //敵ステータス宣言
    public int St1BossHp = 10000;
    public int St1BossAttack = 200;
    public int St1BossEigenvalue = 15000;

    //必要なゲームオブジェクトの定義
    public GameObject EnemyBullet;
    GameObject stMychara;
    public GameObject explosionPrefab;
    public GameObject spattackPrefab;

    //弾発射用のもの
    public float targetTime = 3.0f;
    public float currentTime = 0;
    public float TransitionStandBy = 2.0f;
    public float deg = 0;
    public bool isMake = false;
    public bool toNextScene = false;
    public List<MediumEnemyBulletControll> list = new List<MediumEnemyBulletControll> ();
    public bool runShotBullet = false;

    //クリア時アニメーションの変数の定義
    TypefaceAnimator anim;

    public float scChangestandby = 3.0f; //次シーンまでのタイマー

    // Start is called before the first frame update

    void Start () { //マイキャラを探してもらう
        this.stMychara = GameObject.Find ("stMychara");
        Random.InitState (System.DateTime.Now.Millisecond);
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
        int looptime;
        int loopcnt = 0;
        float shotInterval = 0.25f;
        int addradian = 0;
        //shot回数決定
        looptime = Random.Range (1, 5);
        if (d < r1 + r2) {
            //監督スクリプトにhpをへらしてもらう
            PlayerManager.Instance.DecreaseHp (St1BossAttack);

            //コンボリセット
            ScoreManager.Instance.resetCombo ();

            //マイキャラと衝突したら弾を消す
            Destroy (gameObject);
        }
            currentTime += Time.deltaTime;
            if (targetTime < currentTime) {
                looptime = Random.Range (1, 5);
                Debug.Log(looptime);
                deg = 0;
                isMake = false;
                while (looptime != loopcnt) {
                    while (shotInterval < 0) {
                        shotInterval -= Time.deltaTime;
                    }
                    addradian += 360 / looptime;
                    shotBullet (addradian);
                    shotInterval = 0.5f;
                    loopcnt++;
                }
                addradian = 0;
                currentTime = 0.0f;
        }
    }

    //被弾処理
    public void DecreaseHp () {
        int Combo = ScoreManager.Instance.CurrentCombo;
        //被弾時にコンボ値を変更できるようにする
        Debug.Log (PlayerManager.Instance.CurrentPlayerAttack);
        St1BossHp -= PlayerManager.Instance.CurrentPlayerAttack;
        if (St1BossHp <= 0) {
            GameDirector.Instance.enemyGen = false;
            Destroy (gameObject);
            Instantiate (explosionPrefab, transform.position, Quaternion.identity);
            double scrtmp = St1BossEigenvalue * (Combo + 1) * 0.01;
            int add = (int) scrtmp;
            ScoreManager.Instance.AddScore (add);
            GameDirector.Instance.shotLv++;
            FadeManager.Instance.LoadScene ("St1ed", 2.0f);
            SoundManager.Instance.PlaySeByName ("BOSS_Gekiha");
        }
    }

    public void shotBullet (int addradian) {
        float hankei = 2f; //弾オブジェクトを配置する円の半径
        float BulletInterval = 30f; //弾を生成する角度
        currentTime = 0;　 //タイマーを初期化
        while (deg <= 360 - BulletInterval + addradian) {
            GameObject clone = (GameObject) Instantiate (EnemyBullet, transform.position, Quaternion.identity);
            clone.GetComponent<MediumEnemyBulletControll> ().SetVelocity ((clone.GetComponent<MediumEnemyBulletControll> ().VelocitySetting (deg, 3) / 300));
            deg += BulletInterval;
        }
    }

    public void shotSpattack () {

    }
}