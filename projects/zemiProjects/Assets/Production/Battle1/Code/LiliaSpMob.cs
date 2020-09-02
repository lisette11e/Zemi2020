/*リリアモブ
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiliaSpMob : MonoBehaviour {
    public float targettime; //モブが生きている時間
    public float shotinterval; //モブが弾を発射する時間の間隔
    public GameObject LiliaMobBulletPrefab;
    // Start is called before the first frame update
    void Start () {
        targettime = 10.0f;
        shotinterval = 0.25f;
    }

    // Update is called once per frame
    void Update () {
        targettime -= Time.deltaTime;
        shotinterval -= Time.deltaTime;

        if (shotinterval < 0.0f) {
            Instantiate (LiliaMobBulletPrefab, transform.position, Quaternion.identity);
            shotinterval = 0.25f;
        }
        if (targettime < 0.0f) {
            Destroy (gameObject);
        }
    }
}