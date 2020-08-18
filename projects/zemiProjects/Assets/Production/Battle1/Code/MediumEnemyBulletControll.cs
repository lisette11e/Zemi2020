using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyBulletControll : MonoBehaviour {
    public Vector2 MyPos;
    public Vector2 bulletVector;
    Renderer targetRenderer;
    GameObject stMychara;
    float fallspd; //落ちてくる速度を設定する子

    //敵座標
    private Vector2 charaPos;
    public Vector2 CharaPos {
        set {
            charaPos = value;
        }
    }

    void Start () {
        MyPos = this.gameObject.transform.position;
        targetRenderer = GetComponent<Renderer> ();
        this.stMychara = GameObject.Find ("stMychara");
        this.fallspd = 0.01f + 0.02f * Random.value;
    }

    void Update () {
        transform.Translate (0, -fallspd, 0, Space.World);
        //一番下に行ったらゲームオブジェクトから消滅させる
        if (transform.position.y < -5.5f) {
            Destroy (gameObject);
        }
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
        }
    }

    public void shot () {
        this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (MyPos.x - charaPos.x, MyPos.y - charaPos.y);

    }

}