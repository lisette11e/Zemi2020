/* ザコ敵生成 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyGen : MonoBehaviour {
    public GameObject SmallEnemyPrefab;

    // Start is called before the first frame update
    void Start () {
        //1秒ごとに弾を生成する
        InvokeRepeating ("EnemyGen", 1, 1);
    }

    // Update is called once per frame
    void Update () {

    }

    void EnemyGen () {
        //x軸のランダムな位置に敵オブジェクトを生成させる
        Instantiate (SmallEnemyPrefab, new Vector3 (-2.5f + 5 * Random.value, 6, 0), Quaternion.identity);
    }
}