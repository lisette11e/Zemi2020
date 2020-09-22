using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chgSprite : MonoBehaviour
{
    public Sprite spriteMae;
    public Sprite spriteAto;

    public GameObject chara;

    void Start(){
      chara = GameObject.Find("stMychara");
    }

    // Start is called before the first frame update
    public void OnClick()
    {
        if(!PlayerManager.Instance.ToChange){
            chara.GetComponent<SpriteRenderer>().sprite = spriteAto;
        }else{
            chara.GetComponent<SpriteRenderer>().sprite = spriteMae;
        }
        PlayerManager.Instance.PlayerSwap();
    }
}
