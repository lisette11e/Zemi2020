﻿/*ザコ敵マネージャー */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyManager : MonoBehaviour {
    float fallspd; //落ちてくる速度を設定する子

    //敵ステータス宣言
    public int EnemyMobSmallHp = 100;
    public int EnemyMobSmallAttack = 50;
    public int EnemyMobSmallEigenvalue = 1000;

    // Start is called before the first frame update
    GameObject stMychara;
    public GameObject explosionPrefab;
    void Start () { //マイキャラを探してもらう
        this.stMychara = GameObject.Find ("stMychara");

        //隕石が降ってくる速度をランダムで変えてやる
        this.fallspd = 0.01f + 0.02f * Random.value;
    }

    // Update is called once per frame
    void Update () {
        //どんどん降ってくる
        transform.Translate (0, -fallspd, 0, Space.World);
        //一番下に行ったらゲームオブジェクトから消滅させる
        if (transform.position.y < -5.5f) {
            Destroy (gameObject);
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
            PlayerManager.Instance.DecreaseHp (EnemyMobSmallAttack);

            //コンボリセット
            ScoreManager.Instance.resetCombo ();

            //マイキャラと衝突したら弾を消す
            Destroy (gameObject);
        }
    }

    //被弾処理
    public void DecreaseHp () {
        int Combo = ScoreManager.Instance.CurrentCombo;
        //被弾時にコンボ値を変更できるようにする
        Debug.Log (PlayerManager.Instance.CurrentPlayerAttack);
        EnemyMobSmallHp -= PlayerManager.Instance.CurrentPlayerAttack;
        if (EnemyMobSmallHp <= 0) {
            Destroy (gameObject);
            Instantiate (explosionPrefab, transform.position, Quaternion.identity);
            GameDirector.Instance.EnemyMobSmallDestroyCount++;
            double scrtmp = 1000 * (Combo + 1) * 0.01;
            int add = (int) scrtmp;
            ScoreManager.Instance.AddScore (add);
        }
    }
    //必殺モード発動時用
    public void SpecialMoveDestroy () {
        int Combo = ScoreManager.Instance.CurrentCombo;
        Destroy (gameObject);
        Instantiate (explosionPrefab, transform.position, Quaternion.identity);
        GameDirector.Instance.EnemyMobSmallDestroyCount++;
        double scrtmp = 1000 * (Combo + 1) * 0.01;
        int add = (int) scrtmp;
        ScoreManager.Instance.AddScore (add);
    }
}