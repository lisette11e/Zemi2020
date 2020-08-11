/* 自機弾操作
 * 0623 スコア計算処理追加＠萩原
 * 0630 スコア計算修正＠萩原
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControll : MonoBehaviour
{
    public GameObject explosionPrefab;

    void Start(){

    }

    void Update () {
  //　自機弾は上に上がってくる
    transform.Translate (0, 0.05f, 0);

    if (transform.position.y > 5) {
      Destroy (gameObject);
    }
  }

  void OnTriggerEnter2D (Collider2D coll) {
    //接触したオブジェクトのHPをへらす
    coll.gameObject.SendMessage("DecreaseHp");
    Destroy (gameObject);
    int Combo = ScoreManager.instance.CurrentCombo;
    int EigenValue;
    //当たったオブジェクトを調べる（もうちょっと良いコードありそう）
    switch (coll.gameObject.tag) {
      case "SmallEnemyMob":
        EigenValue = 1000;
        break;
      case "BigEnemyMob":
        EigenValue = 1500;
        break;
      case "MediumBoss":
        EigenValue = 5000;
        break;
      case "BigBoss":
        EigenValue = 15000;
        break;
      default:
        EigenValue = 500;
        break;
    }
    double scrtmp = EigenValue * (Combo + 1) * 0.01;
    int add = (int) scrtmp;
    ScoreManager.instance.AddScore (add);
  }

}
