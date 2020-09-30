using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyBulletControll : MonoBehaviour {
    public Vector2 MyPos;
    public Vector2 bulletVector;
    public Vector3 velocity;
    Renderer targetRenderer;
    GameObject stMychara;
    public GameObject targetEnemy;
    float fallspd; //落ちてくる速度を設定する子
    bool isTrigger = false;

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
        if (isTrigger == true) {
            transform.Translate (velocity * -1, Space.World);
        } else {
            transform.Translate (velocity, Space.World);
        }

        if (!GetComponent<Renderer> ().isVisible) {
            Destroy (this.gameObject);
        }

    }

    public void SetVelocity (Vector2 tmpvel) {
        velocity = tmpvel;
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.name == "stMychara") {
            if (PlayerManager.Instance.isYuhAbilityTriggered == true && isTrigger == false) {
                isTrigger = true; 
            } else {
                PlayerManager.Instance.DecreaseHp (50);
                //コンボリセット
                ScoreManager.Instance.resetCombo ();
                Destroy (gameObject);
            }
        } else if (isTrigger == true) {
            targetEnemy = col.gameObject;
            Destroy (gameObject);
            int Combo = ScoreManager.Instance.CurrentCombo;
            //当たったオブジェクトを調べる（もうちょっと良いコードありそう）
            switch (col.gameObject.tag) {
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

    public Vector2 VelocitySetting (float direction, float speed) {
        Vector2 V;
        V.x = Mathf.Cos (Mathf.Deg2Rad * direction) * speed;
        V.y = Mathf.Sin (Mathf.Deg2Rad * direction) * speed;
        return V;
    }
}