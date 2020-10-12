/* 敵弾生成 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybulletgen : MonoBehaviour {
    public GameObject EnemybulletPrefab;

    // Start is called before the first frame update
    void Start () {
        if(GameDirector.Instance.enemyGen == true){
        //ランダムなタイミングでに弾を生成する
        InvokeRepeating ("GenBullet", 0.5f, 1);
        }

    }

    // Update is called once per frame
    void Update () {

    }

    void GenBullet () {
        //x軸のランダムな位置に弾オブジェクトを生成させる
        Instantiate (EnemybulletPrefab, new Vector3 (-2.5f + 5 * Random.value, 6, 0), Quaternion.identity);
    }
}