/*　自機コントロール */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharaControll : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource SE;
    // Start is called before the first frame update
    void Start()
    {
        SE = GetComponent<AudioSource>();
    }
    public GameObject LiliaLv1;
    public GameObject LiliaLv2;
    public GameObject LiliaLv3;
    public GameObject LiliaSp;
    public GameObject YuLv1;
    public GameObject YuLv2;
    public GameObject YuLv3;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.01f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.01f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
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
        }
    }
}
