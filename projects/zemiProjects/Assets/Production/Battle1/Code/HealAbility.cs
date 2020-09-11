using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAbility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && PlayerManager.Instance.ManualHealCount <= 2)
        {
            if (PlayerManager.Instance.ToChange == false)
            {
                PlayerManager.Instance.CurrentPlayerHp += PlayerManager.Instance.LiliaHp / 2;
                PlayerManager.Instance.StandbyPlayerHp += PlayerManager.Instance.YuhHp / 2;
            }
            else
            {
                PlayerManager.Instance.CurrentPlayerHp += PlayerManager.Instance.LiliaHp / 2;
                PlayerManager.Instance.StandbyPlayerHp += PlayerManager.Instance.YuhHp / 2;
            }

            //被弾処理のコードを使ってHPバーリセット
            PlayerManager.Instance.DecreaseHp(0);
        }
    }
}
