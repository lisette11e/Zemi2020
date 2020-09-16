using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YuBulletControll : MonoBehaviour {
    public GameObject explosionPrefab;
    public GameObject targetEnemy;
    Renderer targetRenderer;
    void Start () {
        targetRenderer = GetComponent<Renderer> ();
    }

    void Update () {
        //　自機弾は上に上がってくる
        transform.Translate (0, 0.05f, 0);

        if (!GetComponent<Renderer> ().isVisible) {
            Destroy (gameObject);
        }
    }

    void OnTriggerEnter2D (Collider2D collision) {
        //接触したオブジェクトのHPをへらす
        targetEnemy = collision.gameObject;
        Destroy (gameObject);
        int Combo = ScoreManager.Instance.CurrentCombo;
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