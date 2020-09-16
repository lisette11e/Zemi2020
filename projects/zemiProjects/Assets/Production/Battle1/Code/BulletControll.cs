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
    public GameObject targetEnemy;
    Renderer targetRenderer;

    public Sprite LiliaLv1;
    public Sprite LiliaLv2;
    public Sprite LiliaLv3;
    public Sprite LiliaSp;
    public Sprite YuLv1;
    public Sprite YuLv2;
    public Sprite YuLv3;
    public Sprite YuSp;

    //ホーミング用
    public float diffusionAngle = 0.5f;
    public float bulletSpeed = 0.05f;
    public float directionx; //x軸方向にどれだけ進むか
    public float directiony; //y軸方向にどれだけ進むか

    void Start()
    {
        targetRenderer = GetComponent<Renderer>();
        directionx = Random.value;
        directiony = Random.value;
        SpriteRenderer MainSR = gameObject.GetComponent<SpriteRenderer>();

        //発射する弾の分岐
        if (GameDirector.Instance.ToSpecialAttack == true)
        {
            if (PlayerManager.Instance.ToChange == true)
            {
                MainSR.sprite = YuSp;
            }
            else
            {
                MainSR.sprite = LiliaSp;
            }
        }
        else
        {
            switch (GameDirector.Instance.shotLv)
            {
                case 1:
                    if (PlayerManager.Instance.ToChange == true)
                    {
                        MainSR.sprite = YuLv1;
                    }
                    else
                    {
                        MainSR.sprite = LiliaLv1;
                    }
                    break;

                case 2:
                    if (PlayerManager.Instance.ToChange == true)
                    {
                        MainSR.sprite = YuLv2;
                    }
                    else
                    {
                        MainSR.sprite = LiliaLv2;
                    }
                    break;
                case 3:
                    if (PlayerManager.Instance.ToChange == true)
                    {
                        MainSR.sprite = YuLv3;
                    }
                    else
                    {
                        MainSR.sprite = LiliaLv3;
                    }
                    break;
            }
        }
    }

    void Update()
    {
        //　自機弾の発射方向
        if (PlayerManager.Instance.ToChange == false)
        {
            transform.Translate(0, 0.05f, 0);
        }
        else
        {
            transform.Translate(directionx, directiony, 0);
        }

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