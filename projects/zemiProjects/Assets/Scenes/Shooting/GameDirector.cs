/* 監督スクリプト
 * 0624 キャラステータス追加＠萩原
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//キャラステータス宣言
public class Charater{
  public int Hp;
  public int Lv;
  public int Attack;
}

public class Player : Charater{
  public int abilitycount;
}




public class GameDirector : MonoBehaviour
{
  //各種ステータス宣言
  public int AutoHealCount = 0;
  public int ManualHealCount = 0;

    GameObject hpGauge;
    void Start()
    {
        //キャラ設定初期化
        Player Lilia = new Player();
        Lilia.Hp = 500;
        Lilia.Lv = 1;
        Lilia.Attack = 120;
        Lilia.abilitycount = 0;

        Player Yuh = new Player();
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
