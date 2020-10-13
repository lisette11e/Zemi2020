using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backhome : MonoBehaviour
{
    // Update is called once per frame
    public void Onclick()
    {
        FadeManager.Instance.LoadScene ("title", 2.0f);
    }
}
