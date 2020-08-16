using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyManager : MonoBehaviour {

    float fallspd; //落ちてくる速度を設定する子

    //敵ステータス宣言
    public int EnemyMobMediumHp = 1000;
    public int EnemyMobMediumAttack = 100;
    public int EnemyMobMediumEigenvalue = 5000;

    // Start is called before the first frame update
    GameObject stMychara;
    public GameObject explosionPrefab;
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
            PlayerManager.Instance.DecreaseHp (50);

            //コンボリセット
            ScoreManager.Instance.resetCombo ();

            //マイキャラと衝突したら弾を消す
            Destroy (gameObject);
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
            GameDirector.Instance.EnemyMobSmallDestroyCount++;
            Debug.Log (GameDirector.Instance.EnemyMobSmallDestroyCount);
        }
    }
}