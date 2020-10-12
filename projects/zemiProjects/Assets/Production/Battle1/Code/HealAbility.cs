using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAbility : MonoBehaviour
{    
    public void Onclick(){
        //カットイン変数の定義
        Animator anim = null;
        Debug.Log(PlayerManager.Instance.CurrentPlayerHp);
        if (PlayerManager.Instance.ManualHealCount <= 2)
        {
            if (PlayerManager.Instance.ToChange == false)
            {
                PlayerManager.Instance.CurrentPlayerHp += PlayerManager.Instance.LiliaHp / 2;
                //カットイン
                anim.SetBool("Cut In",true);
            }
            else
            {
                PlayerManager.Instance.CurrentPlayerHp += PlayerManager.Instance.YuhHp / 2;
                //カットイン
                anim.Play();
            }
            //被弾処理のコードを使ってHPバーリセット
            Debug.Log(PlayerManager.Instance.CurrentPlayerHp);
            PlayerManager.Instance.redrawHpgauge();
        }
    }
}
