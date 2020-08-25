/*　自機コントロール */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharaControll : MonoBehaviour {
	// Start is called before the first frame update
	void Start () {

	}
	public GameObject bulletPrefab;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (-0.01f, 0, 0);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (0.01f, 0, 0);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			Instantiate (bulletPrefab, transform.position, Quaternion.identity);
		}
	}
}