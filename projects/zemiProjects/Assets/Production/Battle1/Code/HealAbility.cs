using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAbility : MonoBehaviour
{    
    //ヒール処理　最大HPの半分を回復
    public void Onclick(){
        Debug.Log(PlayerManager.Instance.CurrentPlayerHp);
        if (PlayerManager.Instance.ManualHealCount <= 2)
        {
            if (PlayerManager.Instance.ToChange == false)
            {
                PlayerManager.Instance.CurrentPlayerHp += PlayerManager.Instance.LiliaHp / 2;
            }
            else
            {
                PlayerManager.Instance.CurrentPlayerHp += PlayerManager.Instance.YuhHp / 2;
            }
            //被弾処理のコードを使ってHPバーリセット
            Debug.Log(PlayerManager.Instance.CurrentPlayerHp);
            PlayerManager.Instance.redrawHpgauge();
        }
    }
}
