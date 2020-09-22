using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chgSprite : MonoBehaviour
{
    public Sprite spriteMae;
    public Sprite spriteAto;

    private bool chFlg = false;

    // Start is called before the first frame update
    public void changeSprite()
    {
        if(!chFlg){
            this.gameObject.GetComponent<Image>().sprite = spriteAto;
            chFlg = true;
        }else{
            this.gameObject.GetComponent<Image>().sprite = spriteMae;
            chFlg = false;
        }
    }
}
