using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
	float bgSpeed;
	GameObject director;
  	GameDirector gd;
	void start(){
    director = GameObject.Find("GameDirector");
    gd = director.GetComponent<GameDirector>();		
	}
	void Update () {
		
		transform.Translate (0, -0.05f, 0);
		if (transform.position.y < -12.0f ) {
			transform.position = new Vector3 (0, 12.0f, 0);
		}
	}
}