using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    GameObject ScoreObject;
    int CurrentScore = 0;
    public int CurrentCombo = 1;
      void Start () {
        this.ScoreObject = GameObject.Find("ScoreDisp");
      }

      void Update () {
        this.ScoreObject.GetComponent<Text>().text = CurrentScore.ToString("D6");
      }

      public void AddScore(int adScore){
        CurrentScore += adScore;
        CurrentCombo ++;
      }
}
