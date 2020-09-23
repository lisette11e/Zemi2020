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
    public GameObject bulletPrefab;

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
            if (PlayerManager.Instance.ToChange == false)
            {
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                }
            }

        }
    }
}