using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;//追加しました

public class tamesiManager : MonoBehaviour
{

    public GameObject tamesi_object = null; // Text用のオブジェクトを追加するよ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text tamesi_text = tamesi_object.GetComponent<Text> ();

        tamesi_text.text = "000000";

    }
}
