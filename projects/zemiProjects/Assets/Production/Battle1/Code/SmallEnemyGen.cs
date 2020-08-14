/* ザコ敵生成 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyGen : MonoBehaviour {
    public GameObject SmallEnemyPrefab;
    public float timer = 1.0f; //生成までの時間

    // Start is called before the first frame update
    void Start () { }

    // Update is called once per frame
    void Update () {
        EnemyGen ();
    }

    void EnemyGen () {
        if (GameDirector.Instance.CurrentPhase == 1 || GameDirector.Instance.CurrentPhase == 3) {
            // カウンタ
            timer -= Time.deltaTime;
            if (timer < 0) {
                    // 敵を出現させる
                    Instantiate (SmallEnemyPrefab, new Vector3 (-2.5f + 5 * Random.value, 6, 0), Quaternion.identity);
                    // タイマーのリセット
                    timer = 1.0f;
            }
        }
    }
}