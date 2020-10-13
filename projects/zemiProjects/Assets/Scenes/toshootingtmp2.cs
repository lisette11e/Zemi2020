using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toshootingtmp2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        scChange();
    }
    void scChange(){
        FadeManager.Instance.LoadScene("St1Bossbt", 2.0f);
    }
}
