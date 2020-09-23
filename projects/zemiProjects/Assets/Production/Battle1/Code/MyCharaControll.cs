/*　自機コントロール */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharaControll : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource SE;

    //位置座標
    Vector3 position;
    Vector3 toWorld;

    // Start is called before the first frame update
    void Start()
    {
        SE = GetComponent<AudioSource>();
    }
    public GameObject LiliaLv1;
    public GameObject LiliaLv2;
    public GameObject LiliaLv3;
    public GameObject YuLv1;
    public GameObject YuLv2;
    public GameObject YuLv3;
    public float targetTime = 1.0f;
    public float currentTime = 0.0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)){
          position = Input.mousePosition;
          position.z = 10.0f;
          toWorld = Camera.main.ScreenToWorldPoint(position);
          if(toWorld.y > -3.0f){
            gameObject.transform.position = toWorld;
          }

          currentTime += Time.deltaTime;
          Debug.Log(currentTime);
          if(currentTime > targetTime){
            SE.PlayOneShot(sound1);
            switch (GameDirector.Instance.shotLv)
            {
                case 1:
                    if (PlayerManager.Instance.ToChange == true)
                    {
                        Instantiate(YuLv1, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(LiliaLv1, transform.position, Quaternion.identity);
                    }
                    break;

                case 2:
                    if (PlayerManager.Instance.ToChange == true)
                    {
                        Instantiate(YuLv2, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(LiliaLv2, transform.position, Quaternion.identity);
                    }
                    break;
                case 3:
                    if (PlayerManager.Instance.ToChange == true)
                    {
                        Instantiate(YuLv3, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(LiliaLv3, transform.position, Quaternion.identity);
                    }
                    break;
                  }
                  currentTime = 0.0f;
                }

        }
    }
}
