using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControll : MonoBehaviour //自機弾の操作
{
    public GameObject explosionPrefab;

    void Start(){
    }

    void Update () {
  //　自機弾は上に上がってくる
    transform.Translate (0, 0.2f, 0);

    if (transform.position.y > 5) {
      Destroy (gameObject);
    }
  }

  void OnTriggerEnter2D(Collider2D coll) {
  // あたったら消す
  Destroy (coll.gameObject);
  Destroy (gameObject);

  //スコア更新 神谷制作・萩原debug0615
  GameObject.Find("ScoreGUI").GetComponent<ScoreManager>().AddScore();
  }

}
