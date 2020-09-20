using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_to_Prologue : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            FadeManager.Instance.LoadScene("Prologue", 2.0f);
        }

    }
}
