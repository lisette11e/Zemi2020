/* キャラクタースワップ
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaSwap : MonoBehaviour {
  GameObject director;
  GameDirector gd;
  void Start () {
    director = GameObject.Find ("GameDirector");
    gd = director.GetComponent<GameDirector> ();
  }
  public void Swap () {

  }
}