﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControll : MonoBehaviour //自機弾の操作
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (0, 0.1f, 0);

		if (transform.position.y > 5) {
			Destroy (gameObject);
		}
    }
}
