/*　自機コントロール */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharaControll : MonoBehaviour {
    //位置座標
    Vector3 position;
    Vector3 toWorld;

    // Start is called before the first frame update
    void Start () { }
    public GameObject LiliaLv1;
    public GameObject LiliaLv2;
    public GameObject LiliaLv3;
    public GameObject YuLv1;
    public GameObject YuLv2;
    public GameObject YuLv3;
    public float targetTime = 1.0f;
    public float currentTime = 0.0f;
    // Update is called once per frame
    void Update () {
        //タップ→ホールド検知で自動的に弾発射
        if (Input.GetMouseButton (0)) {
            position = Input.mousePosition;
            position.z = 10.0f;
            toWorld = Camera.main.ScreenToWorldPoint (position);
            if (toWorld.y > -3.0f) {
                gameObject.transform.position = toWorld;
            }

            currentTime += Time.deltaTime;
            if (currentTime > targetTime) {
                switch (GameDirector.Instance.shotLv) {
                    case 1:
                        if (PlayerManager.Instance.ToChange == true) {
                            Instantiate (YuLv1, transform.position, Quaternion.identity);
                        } else {
                            Instantiate (LiliaLv1, transform.position, Quaternion.identity);
                        }
                        SoundManager.Instance.PlaySeByName ("SHOTLv1");
                        break;

                    case 2:
                        if (PlayerManager.Instance.ToChange == true) {
                            Instantiate (YuLv2, transform.position, Quaternion.identity);
                        } else {
                            Instantiate (LiliaLv2, transform.position, Quaternion.identity);
                        }
                        SoundManager.Instance.PlaySeByName ("SHOTLv2");
                        break;
                    case 3:
                        if (PlayerManager.Instance.ToChange == true) {
                            Instantiate (YuLv3, transform.position, Quaternion.identity);
                            SoundManager.Instance.PlaySeByName ("SHOTLv3_Yu_long");
                        } else {
                            Instantiate (LiliaLv3, transform.position, Quaternion.identity);
                            SoundManager.Instance.PlaySeByName ("SHOTLv3_Lilia_short");
                        }
                        break;
                }
                currentTime = 0.0f;
            }

        }
    }
}