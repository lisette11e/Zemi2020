using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(GameDirector.Instance.CurrentPhase == 3){
            GameDirector.Instance.toDisplayBossArea = true;
        }
    }
}
