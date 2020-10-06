using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGround : MonoBehaviour
{
    RectTransform BG;
    void start() { 
        BG = GetComponent<RectTransform>();
    }
    void Update()
    {
        if (GameDirector.Instance.ToSpecialAttack == true)
        {
            BG.Translate (0, -20.0f, 0);
        }
        else
        {
           BG.Translate (0, -10.0f, 0);
        }

        if (BG.localPosition.y < -2000.0f)
        {
            BG.localPosition = new Vector3(0, 2000.0f, 0);
        }
    }
}