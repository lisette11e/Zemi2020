using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyBulletControll : MonoBehaviour {
    public Vector2 MyPos;
    public Vector2 bulletVector;
    public Vector3 velocity;
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
        //VelocitySettingで取得したVelocityをUpdate`関数で動かす
        transform.Translate (velocity, Space.World);

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

        if (!GetComponent<Renderer> ().isVisible) {
            Destroy (this.gameObject);
        }
    }

    public void SetVelocity (Vector2 tmpvel) {
        velocity = tmpvel;
    }

    public Vector2 VelocitySetting (float direction, float speed) {
        Vector2 V;
        V.x = Mathf.Cos (Mathf.Deg2Rad * direction) * speed;
        V.y = Mathf.Sin (Mathf.Deg2Rad * direction) * speed;
        return V;
    }
}