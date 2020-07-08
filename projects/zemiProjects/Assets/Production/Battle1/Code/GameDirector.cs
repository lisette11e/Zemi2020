/* 監督スクリプト
 * 0624 キャラステータス追加＠萩原
 * 0701 敵キャラステータス追加＠萩原
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//キャラステータス宣言
public class Character{
  public int Hp;
  public int Attack;
}

public class Player : Character{
  public int abilitycount;
  public int Lv;
}

public class Enemy : Character{
  public int eigenvalue; //敵倒したときの基礎値
}



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
    GameObject hpGauge;
    void Start()
    {
        //リリア
        Player Lilia = new Player();
        Lilia.Hp = 500;
        Lilia.Lv = 1;
        Lilia.Attack = 120;
        Lilia.abilitycount = 0;
        //ユウ
        Player Yuh = new Player();
        Yuh.Hp = 400;
        Yuh.Lv = 1;
        Yuh.Attack = 100;
        Yuh.abilitycount = 0;

        CurrentPlayerHp = Lilia.Hp;
        CurrentPlayerLv = Lilia.Lv;
        CurrentPlayerAttack = Lilia.Attack;
        CurrentPlayerabilitycount = Lilia.abilitycount;
        StandbyPlayerHp = Yuh.Hp;
        StandbyPlayerLv = Yuh.Lv;
        StandbyPlayerAttack = Yuh.Attack;
        StandbyPlayerabilitycount = Yuh.abilitycount;


        //最初はリリアが出撃するようにする（仕様変更あれば対応可）




        //敵・ざこいの（小）
        Enemy EnemyMobSmall = new Enemy();
        EnemyMobSmall.Hp = 100;
        EnemyMobSmall.Attack = 50;
        EnemyMobSmall.eigenvalue = 1000;

        //敵・ざこいの（大）
        /*レベルが上がっていく形と思われるので、ひとまず最小値で設定してあります　以降の敵も同じです */
        Enemy EnemyMobBig = new Enemy();
        EnemyMobBig.Hp = 500;
        EnemyMobBig.Attack = 100;
        EnemyMobBig.eigenvalue = 1500;

        //敵・中ボス
        Enemy BossMiddle = new Enemy();
        BossMiddle.Hp = 1000;
        BossMiddle.Attack = 100;
        BossMiddle.eigenvalue = 5000;

        //敵・大ボス
        Enemy BossLarge = new Enemy();
        BossLarge.Hp = 10000;
        BossLarge.Attack = 200;
        BossLarge.eigenvalue = 15000;


        //HPゲージ初期化
        this.hpGauge = GameObject.Find("hpGauge");



    }

    //被弾処理
    public void DecreaseHp()
    {
      //被弾時にコンボ値を変更できるようにする

        this.hpGauge.GetComponent<Image> ().fillAmount -= 0.05f;

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
