/*　スコア管理
 *　0617　初版＠神谷
 *　0623　スコアの計算方法変更＠萩原
 *  0630　コンボ可視化＠萩原
 *　0803　必殺モードに伴い処理変更＠萩原
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager> {

  GameObject ScoreObject;
  GameObject ComboObject;
  GameObject ComboDisp;

  int CurrentScore;
  public int CurrentCombo;

  void Start () {
    this.ScoreObject = GameObject.Find ("ScoreDisp");
    this.ComboObject = GameObject.Find ("ComboGUI");
    this.ComboDisp = GameObject.Find ("ComboDisp");
  }

  void Update () {
    this.ScoreObject.GetComponent<TextMeshProUGUI> ().text = CurrentScore.ToString ("D6");
    this.ComboDisp.GetComponent<TextMeshProUGUI> ().text = CurrentCombo.ToString ();
  }

  public void AddScore (int adScore) {
    CurrentScore += adScore;
    CurrentCombo++;
  }

  public void resetCombo () {
    CurrentCombo = 0;
  }
}