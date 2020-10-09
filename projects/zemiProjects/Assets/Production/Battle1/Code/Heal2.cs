using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Onclick()
    {
        Debug.Log(PlayerManager.Instance.CurrentPlayerHp);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
