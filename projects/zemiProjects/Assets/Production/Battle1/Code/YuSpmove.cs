/*
ユウのアビリティのフラグ管理
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YuSpmove : MonoBehaviour {
    public float targettime; //モブが生きている時間
    // Start is called before the first frame update
    void Start () {
        if (PlayerManager.Instance.ToChange == true) {
            targettime = 10.0f;
            flagOperation ();
        }
    }

    // Update is called once per frame
    void Update () {
        targettime -= Time.deltaTime;
        if (targettime < 0.0f) {
            PlayerManager.Instance.isYuhAbilityTriggered = false;
        }
    }
    void flagOperation () {
        PlayerManager.Instance.isYuhAbilityTriggered = true;
    }
}