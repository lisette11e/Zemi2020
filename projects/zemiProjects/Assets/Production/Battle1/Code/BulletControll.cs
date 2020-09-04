/* 自機弾操作
 * 0623 スコア計算処理追加＠萩原
 * 0630 スコア計算修正＠萩原
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControll : MonoBehaviour {
  public GameObject explosionPrefab;
  public GameObject targetEnemy;
  Renderer targetRenderer;

  //ホーミング用
  public float diffusionAngle = 0.5f;
  public float bulletSpeed = 0.05f;
  public float directionx; //x軸方向にどれだけ進むか
  public float directiony; //y軸方向にどれだけ進むか

  void Start () {
    targetRenderer = GetComponent<Renderer> ();
    directionx = Random.value;
    directiony = Random.value;
  }

  void Update () {
    //　自機弾の発射方向
    if (PlayerManager.Instance.ToChange == false) {
      transform.Translate (0, 0.05f, 0);
    } else {
      transform.Translate (directionx, directiony, 0);
    }

    if (!GetComponent<Renderer> ().isVisible) {
      Destroy (gameObject);
    }
  }

  void OnTriggerEnter2D (Collider2D collision) {
    //接触したオブジェクトのHPをへらす
    targetEnemy = collision.gameObject;
    Destroy (gameObject);
    int Combo = ScoreManager.Instance.CurrentCombo;
    int EigenValue;
    //当たったオブジェクトを調べる（もうちょっと良いコードありそう）
    switch (collision.gameObject.tag) {
      case "SmallEnemyMob":
        targetEnemy.GetComponent<SmallEnemyManager> ().DecreaseHp ();
        break;
      case "BigEnemyMob":
        break;
      case "MediumEnemy":
        targetEnemy.GetComponent<MediumEnemyManager> ().DecreaseHp ();
        break;
      case "BigBoss":
        break;
      default:
        Destroy (targetEnemy);
        break;
    }
    double scrtmp = 100 * (Combo + 1) * 0.01;
    int add = (int) scrtmp;
    ScoreManager.Instance.AddScore (add);
  }

}