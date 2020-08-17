using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyBulletControll : MonoBehaviour {
    public Vector2 MyPos;
    public Vector2 bulletVector;
    public Vector2 charaPos;
    Renderer targetRenderer;
    GameObject stMychara;

    void Start () {
        MyPos = this.gameObject.transform.position;
        charaPos = GameObject.FindGameObjectWithTag ("MediumEnemy").transform.position;
        bulletVector = new Vector2 (MyPos.x - charaPos.x, MyPos.y - charaPos.y);
        targetRenderer = GetComponent<Renderer> ();
        this.stMychara = GameObject.Find ("stMychara");
    }

    void Update () {

        //キャラと敵弾の当たり判定
        Vector2 p1 = transform.position;
        Vector2 p2 = this.stMychara.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.2f;
        float r2 = 0.4f;

        if (d < r1 + r2) {
            //監督スクリプトにhpをへらしてもらう
            PlayerManager.Instance.DecreaseHp (10);

            //コンボリセット
            ScoreManager.Instance.resetCombo ();

            //マイキャラと衝突したら弾を消す 
            Destroy (gameObject);
        }
    }

    public void shot () {
        this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (MyPos.x - charaPos.x, MyPos.y - charaPos.y);
    }

}