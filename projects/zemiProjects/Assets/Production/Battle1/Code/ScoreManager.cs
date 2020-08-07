/*　スコア管理
 *　0617　初版＠神谷
 *　0623　スコアの計算方法変更＠萩原
 *  0630　コンボ可視化＠萩原
 *　0803　必殺モードに伴い処理変更＠萩原
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
  public static ScoreManager instance　 = null; //シングルトンのおまじない

    GameObject ScoreObject;
    GameObject ComboObject;
    GameObject ComboDisp;


    int CurrentScore = 0;
    public int CurrentCombo = 0;

      void Start () {
        this.ScoreObject = GameObject.Find("ScoreDisp");
        this.ComboObject = GameObject.Find("ComboGUI");
        this.ComboDisp = GameObject.Find("ComboDisp");
      }

      void Update () {
        this.ScoreObject.GetComponent<Text>().text = CurrentScore.ToString("D6");
        this.ComboDisp.GetComponent<Text>().text = CurrentCombo.ToString();
      }

      public void AddScore(int adScore){
        CurrentScore += adScore;
        CurrentCombo ++;
      }

      public void resetCombo(){
        CurrentCombo = 0;
      }
}
