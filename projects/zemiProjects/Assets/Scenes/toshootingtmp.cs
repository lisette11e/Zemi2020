using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toshootingtmp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        scChange();
    }
    void scChange(){
        FadeManager.Instance.LoadScene("shootingMain", 2.0f);
    }
}
