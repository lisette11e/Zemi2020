using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chgSprite : MonoBehaviour
{
    public Sprite spriteMae;
    public Sprite spriteAto;

    private bool chFlg = false;
    private GameObject chara;

    void Start(){
      chara = GameObject.Find("stMychara");
    }

    // Start is called before the first frame update
    public void Oncilck()
    {
        if(!PlayerManager.Instance.ToChange){
            chara.GetComponent<SpriteRenderer>().sprite = spriteAto;
            PlayerManager.Instance.ToChange = true;
        }else{
          chara.GetComponent<SpriteRenderer>().sprite = spriteMae;
            PlayerManager.Instance.ToChange = false;
        }
        PlayerManager.Instance.PlayerSwap();
    }
}
