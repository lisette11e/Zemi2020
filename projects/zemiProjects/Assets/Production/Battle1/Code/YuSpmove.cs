/*
ユウのアビリティのフラグ管理
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YuSpmove : MonoBehaviour {
  float yuskilltimer;
  void Update () {
    if (PlayerManager.Instance.isYuhAbilityTriggered == true) {
      yuskilltimer += Time.deltaTime;
      if (yuskilltimer > 10.0f) {
        PlayerManager.Instance.isYuhAbilityTriggered = false;
      }

    }
  }
  public void Onclick () {
    yuskilltimer = 0.0f;
    if (PlayerManager.Instance.ToChange == true) {
      PlayerManager.Instance.isYuhAbilityTriggered = true;
    }
  }
}