using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAbility : MonoBehaviour {
    //カットイン変数の定義
    private Animator anim;

    public void Onclick () {
        //カットインコンポーネント取得
        this.anim = GetComponent<Animator> ();
        Debug.Log (PlayerManager.Instance.CurrentPlayerHp);
        if (PlayerManager.Instance.ManualHealCount <= 2) {
            if (PlayerManager.Instance.ToChange == false) {
                PlayerManager.Instance.CurrentPlayerHp += PlayerManager.Instance.LiliaHp / 2;
                //カットイン処理
                anim.SetTrigger ("Space");
            } else {
                PlayerManager.Instance.CurrentPlayerHp += PlayerManager.Instance.YuhHp / 2;
                //カットイン処理
                anim.SetTrigger ("Space");
            }
            //被弾処理のコードを使ってHPバーリセット
            Debug.Log (PlayerManager.Instance.CurrentPlayerHp);
            PlayerManager.Instance.redrawHpgauge ();
            SoundManager.Instance.PlaySeByName ("HPcure");
        }
    }
}