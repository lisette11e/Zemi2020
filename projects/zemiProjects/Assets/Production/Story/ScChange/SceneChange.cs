using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    void ToPrologue()
    {
        FadeManager.Instance.LoadScene("Prologue", 2.0f);
    }

    void ToSt1OP()
    {
        FadeManager.Instance.LoadScene("St1op", 2.0f);
    }

    void ToSt1ed()
    {
        FadeManager.Instance.LoadScene("St1ed", 2.0f);
    }

    void ToBattle()
    {
        FadeManager.Instance.LoadScene("shootingMain", 2.0f);
    }
}
