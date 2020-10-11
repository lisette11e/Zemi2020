using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenLiliaMob : MonoBehaviour {
    public GameObject lilia;
    public GameObject LiliaSpMob;
    public Transform liliapos;
    // Start is called before the first frame update

  //リリアアビリティ　クリック時にリリアモブのPrefabを生成
    public void Onclick(){
      lilia = GameObject.Find ("stMychara");
      liliapos = lilia.GetComponent<Transform> ();
      Vector3 pos = liliapos.position;
      if(PlayerManager.Instance.LiliaAbilityCount <= 2){
        Instantiate (LiliaSpMob, new Vector3 (pos.x + 1.0f, pos.y, 0.0f), Quaternion.identity);
        Instantiate (LiliaSpMob, new Vector3 (pos.x - 1.0f, pos.y, 0.0f), Quaternion.identity);
      }
    }
}
