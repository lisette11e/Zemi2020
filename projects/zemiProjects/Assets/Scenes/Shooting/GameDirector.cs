/* 監督スクリプト
 * 0624 キャラステータス追加＠萩原
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//キャラステータス宣言
public class Character{
  public int Hp;　//体力
  public int Attack;　//攻撃力
}

public class Player : Character{
  public int Lv;　//プレイヤーキャラのレベル
  public int abilitycount;　//アビリティのカウント
}

public class Enemy : Character{
   public int eigenvalue; //倒したときの基礎値
}


public class GameDirector : MonoBehaviour
{
  //各種ステータス宣言
  public int AutoHealCount = 0;　//自動回復発動カウント
  public int ManualHealCount = 0;　//手動回復発動カウント

    GameObject hpGauge;
    void Start()
    {
        //キャラ設定初期化
        Player Lilia = new Player();　//リリア初期設定
        Lilia.Hp = 500;
        Lilia.Lv = 1;
        Lilia.Attack = 120;
        Lilia.abilitycount = 0;

        Player Yuh = new Player();　//ユウ初期設定
        Yuh.Hp = 400;
        Yuh.Lv = 1;
        Yuh.Attack = 100;
        Yuh.abilitycount = 0;



        //HPゲージ初期化
        this.hpGauge = GameObject.Find("hpGauge");

    }

    //HP減少処理
    public void DecreaseHp()
    {
        this.hpGauge.GetComponent<Image> ().fillAmount -= 0.05f;
    }
}
