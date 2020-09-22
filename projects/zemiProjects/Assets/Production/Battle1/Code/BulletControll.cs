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
  void Start () { }



    //ホーミング用
    public float diffusionAngle = 0.5f;
    public float bulletSpeed = 0.05f;

    void Update()
    {
        //　自機弾の発射方向
        transform.Translate(0, 0.05f, 0);

        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //接触したオブジェクトのHPをへらす
        targetEnemy = collision.gameObject;
        Destroy(gameObject);
        int Combo = ScoreManager.Instance.CurrentCombo;
        //当たったオブジェクトを調べる（もうちょっと良いコードありそう）
        switch (collision.gameObject.tag)
        {
            case "SmallEnemyMob":
                targetEnemy.GetComponent<SmallEnemyManager>().DecreaseHp();
                break;
            case "BigEnemyMob":
                break;
            case "MediumEnemy":
                targetEnemy.GetComponent<MediumEnemyManager>().DecreaseHp();
                break;
            case "BigBoss":
                break;
            default:
                Destroy(targetEnemy);
                break;
        }
        double scrtmp = 100 * (Combo + 1) * 0.01;
        int add = (int)scrtmp;
        ScoreManager.Instance.AddScore(add);
    }
  }
