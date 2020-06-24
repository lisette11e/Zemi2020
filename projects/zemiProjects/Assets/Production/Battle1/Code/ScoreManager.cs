/*　スコア管理
 *　0623　スコアの計算方法変更＠萩原
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    GameObject ScoreObject;
    //スコア関連変数定義＠神谷0617
    int CurrentScore = 0;
    public int CurrentCombo = 1;
      void Start () {
        this.ScoreObject = GameObject.Find("ScoreDisp");
      }

      void Update () {
        this.ScoreObject.GetComponent<Text>().text = CurrentScore.ToString("D6");
      }

      public void AddScore(int adScore){
        //スコア加算＠神谷0617 萩原fix0623
        CurrentScore += adScore;
        CurrentCombo ++;
      }

      public void resetCombo(){
        //被弾時コンボリセット＠萩原0624
        CurrentCombo = 1;
      }
}
