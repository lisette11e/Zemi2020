using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyBulletControll : MonoBehaviour //敵がぶっ放してくる弾　あたったらあかんやつ
{
     float fallspd; //落ちてくる速度を設定する子

    // Start is called before the first frame update
    void Start()
    {
        //隕石が降ってくる速度をランダムで変えてやる
        this.fallspd = 0.01f + 0.1f * Random.value;
    }

    // Update is called once per frame
    void Update()
    {
      　//どんどん降ってくる
        transform.Translate(0, -fallspd, 0, Space.World);
        //一番下に行ったらゲームオブジェクトから消滅させる
        if(transform.position.y < -5.5f){
            Destroy(gameObject);
        }
    }
}
