﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
	void Update () {
		transform.Translate (0, -0.05f, 0);
		if (transform.position.y < -12.0f ) {
			transform.position = new Vector3 (0, 12.0f, 0);
		}
	}
}