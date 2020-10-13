/* 監督スクリプト
 * 0624 キャラステータス追加＠萩原
 * 0701 敵キャラステータス追加＠萩原
 * 0806 シングルトン設計＠萩原
 * 0826 必殺モード＠萩原
 */

/*****
ここに記述された関数と変数は、
他のスクリプトから簡単に参照することが可能です。
参照したい場合は、
GameDirector.instance.（参照したい関数／変数）
と記述すれば大丈夫です。関数の場合は、()が必要です。
*****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : SingletonMonoBehaviour<GameDirector> {

    //各種ステータス宣言
    public float SPmoveTimer = 0.0f;
    public float SPstandbyTimer = 0.0f;
    public bool ToSpecialAttack = false;
    public float bgspeed = -0.05f;
    public int CurrentPhase = 1;
    public int EnemyMobSmallDestroyCount = 0;
    public int shotLv = 1;
    public bool enemyGen = false;
    public bool toDisplayBossArea = false;

    public float StartStandby = 0.0f; //ゲームスタートまでの時間

    GameObject hpGauge;
    public GameObject MediumEnemyPrefab;
    public GameObject St1Boss;
    void Start () {

        /* 仮置です
        //敵・ざこいの（小）
        EnemyMobSmallHp = 100;
        EnemyMobSmallAttack = 50;
        EnemyMobSmallEigenvalue = 1000;

        //敵・ざこいの（大）
        EnemyMobBigHp = 500;
        EnemyMobBigAttack = 100;
        EnemyMobBigEigenvalue = 1500;

        //敵・中ボス
        BossMiddleHp = 1000;
        BossMiddleAttack = 100;
        BossMiddleEigenvalue = 5000;

        //敵・大ボス
        BossLargeHp = 10000;
        BossLargeAttack = 200;
        BossLargeEigenvalue = 15000;
        */

        //HPゲージ初期化
        this.hpGauge = GameObject.Find ("hpGauge");

    }
    void Update () {
        if (EnemyMobSmallDestroyCount >= 50) {
            EnemyMobSmallDestroyCount = 0;
            TransitionPhase ();
        }

        //ゲーム開始時に3秒スタンバイ（アニメーション用）
        while (StartStandby == 3.0f) {
            StartStandby += Time.deltaTime;
        }
        enemyGen = true;

        if (CurrentPhase == 3 && toDisplayBossArea == true) {
            Instantiate (St1Boss, new Vector3 (0.0f, 3.0f, 0.0f), Quaternion.identity);
        }

    }

    //スペシャルムーブ発動
    public void runSpecialMove () {
        Animation anim;
        anim = this.gameObject.GetComponent<Animation> ();
        anim.Play ();

        //フラグスタンバイ
        ToSpecialAttack = true;

        //=====モブ敵を全部ぶちのめす=====
        GameObject[] mobs = GameObject.FindGameObjectsWithTag ("SmallEnemyMob");
        foreach (GameObject mob in mobs) {
            mob.GetComponent<SmallEnemyManager> ().SpecialMoveDestroy ();
        }

        //10秒タイマー始動
        while (SPmoveTimer > 10.0f) {
            SPstandbyTimer += Time.deltaTime;
        }
        ToSpecialAttack = false;
        //スタンバイ
        while (SPstandbyTimer > 10.0f) {
            SPstandbyTimer += Time.deltaTime;
        }
    }
    //フェーズ移行
    public void TransitionPhase () {
        CurrentPhase++;
        if (CurrentPhase == 2) {
            Instantiate (MediumEnemyPrefab, new Vector3 (0.0f, 3.0f, 0.0f), Quaternion.identity);
        }
    }

    void gameStart () {
        Animation anim;
        anim = this.gameObject.GetComponent<Animation> ();
        anim.Play ();

        //タイマー始動
        while (StartStandby == 3.0f) {
            StartStandby += Time.deltaTime;
        }
        enemyGen = true;
    }
}