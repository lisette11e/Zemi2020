using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chgSprite : MonoBehaviour {
  public Sprite spriteMae;
  public Sprite spriteAto;
  public Sprite btnBefore;
  public Sprite btnAfter;
  private bool chFlg = false;
  private GameObject chara;

  void Start () {
    chara = GameObject.Find ("stMychara");
  }

  // ボタンクリック時の処理
  public void Oncilck () {
    if (!PlayerManager.Instance.ToChange) {
      chara.GetComponent<SpriteRenderer> ().sprite = spriteAto;
      this.GetComponent<Image> ().sprite = btnAfter;
      PlayerManager.Instance.ToChange = true;
    } else {
      chara.GetComponent<SpriteRenderer> ().sprite = spriteMae;
      this.GetComponent<Image> ().sprite = btnBefore;
      PlayerManager.Instance.ToChange = false;
    }
    PlayerManager.Instance.PlayerSwap ();
  }
}