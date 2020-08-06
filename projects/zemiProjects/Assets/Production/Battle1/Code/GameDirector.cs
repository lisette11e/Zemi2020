/* 監督スクリプト
 * 0624 キャラステータス追加＠萩原
 * 0701 敵キャラステータス追加＠萩原
 * 0806 シングルトン設計＠萩原
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

public class GameDirector : MonoBehaviour {
  public static GameDirector instance　 = null; //シングルトンのおまじない

  void Awake () {
    GameObject[] obj = GameObject.FindGameObjectsWithTag ("GameDirector");
    if (1 < obj.Length) {
      Destroy (gameObject);
    } else {
      DontDestroyOnLoad (gameObject);
    }
  }
  //各種ステータス宣言
  public int AutoHealCount = 0;
  public int ManualHealCount = 0;
  public int CurrentPlayerHp;
  public int CurrentPlayerLv;
  public int CurrentPlayerAttack;
  public int CurrentPlayerabilitycount;
  public int StandbyPlayerHp;
  public int StandbyPlayerLv;
  public int StandbyPlayerAttack;
  public int StandbyPlayerabilitycount;
  public int SwapHp;
  public int SwapLv;
  public int SwapAttack;
  public int Swapabilitycount;
  public int LiliaHp;
  public int LiliaLv;
  public int LiliaAttack;
  public int LiliaAbilityCount;
  public int YuhHp;
  public int YuhLv;
  public int YuhAttack;
  public int YuhAbilityCount;
  public bool ToChange = false;
  public float SPmoveTimer = 0.0f;
  public float SPstandbyTimer = 0.0f;
  public bool ToSpecialAttack = false;

  GameObject hpGauge;
  void Start () {
    //リリア
    LiliaHp = 500;
    LiliaLv = 1;
    LiliaAttack = 120;
    LiliaAbilityCount = 0;

    //ユウ
    YuhHp = 400;
    YuhLv = 1;
    YuhAttack = 100;
    YuhAbilityCount = 0;

    CurrentPlayerHp = LiliaHp;
    CurrentPlayerLv = LiliaLv;
    CurrentPlayerAttack = LiliaAttack;
    CurrentPlayerabilitycount = LiliaAbilityCount;
    StandbyPlayerHp = YuhHp;
    StandbyPlayerLv = YuhLv;
    StandbyPlayerAttack = YuhAttack;
    StandbyPlayerabilitycount = YuhAbilityCount;

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

  //被弾処理
  public void DecreaseHp (int enemyattack) {
    //被弾時にコンボ値を変更できるようにする
    float currentHp = 0.0f;
    float MaxHp = 0.0f;
    float hpGaugeFill = 0.0f;
    CurrentPlayerHp -= enemyattack;
    currentHp = (float) CurrentPlayerHp;
    if (ToChange == false) {
      MaxHp = LiliaHp;
    } else {
      MaxHp = YuhHp;
    }

    hpGaugeFill = currentHp / MaxHp;
    this.hpGauge.GetComponent<Image> ().fillAmount = hpGaugeFill;

    Debug.Log (currentHp);

  }

  //プレイヤー入れ替え
  public void PlayerSwap () {
    SwapHp = CurrentPlayerHp;
    SwapLv = CurrentPlayerLv;
    SwapAttack = CurrentPlayerAttack;
    Swapabilitycount = CurrentPlayerabilitycount;

    CurrentPlayerHp = StandbyPlayerHp;
    CurrentPlayerLv = StandbyPlayerLv;
    CurrentPlayerAttack = StandbyPlayerAttack;
    CurrentPlayerabilitycount = StandbyPlayerabilitycount;

    StandbyPlayerHp = SwapHp;
    StandbyPlayerLv = SwapLv;
    StandbyPlayerAttack = SwapAttack;
    StandbyPlayerabilitycount = Swapabilitycount;
  }

  //スペシャルムーブ発動
  public void runSpecialMove () {
    ToSpecialAttack = true;
    //10秒タイマー始動
    while (SPmoveTimer == 10.0f) {
      SPstandbyTimer += Time.deltaTime;
    }
    ToSpecialAttack = false;
    //スタンバイ
    while (SPstandbyTimer == 10.0f) {
      SPstandbyTimer += Time.deltaTime;
    }
  }

  //スコア取得
}