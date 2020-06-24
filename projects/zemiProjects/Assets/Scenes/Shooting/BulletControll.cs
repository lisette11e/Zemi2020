/* 自機弾操作
 * 0623 スコア計算処理追加＠萩原
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

  void OnTriggerEnter2D(Collider2D coll) {
  // あたったら消す
  Destroy (coll.gameObject);
  Destroy (gameObject);
  int Combo = GameObject.Find("ScoreGUI").GetComponent<ScoreManager>().CurrentCombo;
  double scrtmp = 1000 * Combo * 0.01;
  int add = (int) scrtmp;
  GameObject.Find("ScoreGUI").GetComponent<ScoreManager>().AddScore(add);
  }

}
