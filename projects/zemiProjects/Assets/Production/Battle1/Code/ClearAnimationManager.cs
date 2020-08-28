/* ClearAnimationを作る
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //追加しました

public class ClearAnimationManager : SingletonMonoBehaviour<ScoreManager>{

    public GameObject clear_object = null;//Textオブジェクト

    // Start is called before the first frame update　初期化のこと
    void Start()
    {
        
    }

    // Update is called once per frame　更新すること
    void Update()
    {
        Text clear_text = clear_object.GetComponent<Text>();

        clear_text.text = "STAGE CLEAR";
    }
}
