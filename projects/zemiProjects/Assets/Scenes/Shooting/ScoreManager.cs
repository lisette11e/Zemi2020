using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    GameObject ScoreObject;
    int CurrentScore = 0;

      void Start () {
        this.ScoreObject = GameObject.Find("ScoreDisp");
      }

      void Update () {
        this.ScoreObject.GetComponent<Text>().text = CurrentScore.ToString("D6");
      }

      public void AddScore(){
        //スコア加算　とりあえず1加算してたのでその処理のままにしました
        CurrentScore++;
      }
}
