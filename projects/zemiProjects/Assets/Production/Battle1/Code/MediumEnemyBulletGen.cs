using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyBulletGen : MonoBehaviour {
    public Vector2 MyPos;
    public Vector2 bulletVector;
    Renderer targetRenderer;
    GameObject stMychara;

    //敵座標
    private Vector2 charaPos;
    public Vector2 CharaPos {
        set {
            charaPos = value;
        }
    }

    void Start () {
        MyPos = this.gameObject.transform.position;
        targetRenderer = GetComponent<Renderer> ();
        this.stMychara = GameObject.Find ("stMychara");
    }

    public void shot () {
        this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (MyPos.x - charaPos.x, MyPos.y - charaPos.y);
    }
}