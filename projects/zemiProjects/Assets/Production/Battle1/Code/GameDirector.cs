/* 監督スクリプト
 * 0624 キャラステータス追加＠萩原
 * 0701 敵キャラステータス追加＠萩原
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameDirector : MonoBehaviour
{
  //各種ステータス宣言
  public int AutoHealCount = 0;
  public int ManualHealCount = 0;
  public int CurrentPlayerHp;
  public int CurrentPlayerLv ;
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
    GameObject hpGauge;
    void Start()
    {
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
        this.hpGauge = GameObject.Find("hpGauge");



    }

    //被弾処理
    public void DecreaseHp(int enemyattack)
    {
      //被弾時にコンボ値を変更できるようにする
      float currentHp = 0.0f;
      float MaxHp = 0.0f;
      float hpGaugeFill = 0.0f;
      CurrentPlayerHp -= enemyattack;
      currentHp = (float)CurrentPlayerHp;
      if(ToChange == false){
        MaxHp = LiliaHp;
      }else{
        MaxHp = YuhHp;
      }

      hpGaugeFill =  currentHp / MaxHp;
        this.hpGauge.GetComponent<Image> ().fillAmount = hpGaugeFill;

      }

    //プレイヤー入れ替え
    public void PlayerSwap(){
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
  }