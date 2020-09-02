using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lec0830 : MonoBehaviour
{   //意味:このプログラミング内にliliaという場所を作る。
    public GameObject lilia;


    // Start is called before the first frame update
    void Start()
    {
        //意味:UnityのSampleScene(左側の一覧)から「Lilia」を持ってきて、さっき作ったliliaと結びつける。
        lilia = GameObject.Find("Lilia");
    }


    // Update is called once per frame
    void Update()
    {
        //意味:このプログラミング内でのTransformの場所を作る。
            //（trは仮定したもの。数学のx,y的なやつ。）
        Transform tr;

        //意味:リリアの TransformをUnityのInspectorから取得。
        tr = lilia.GetComponent<Transform> ();

        //意味:リリアを毎フレームごとにx軸に0.01進める
            //(”Translate”はTransformの「位置(Position)」をいじる。)
                //Unityで小数を使うときはその後に「f」をつける。
                //（Unityのパラメータをいじるときは、整数であってもfをつける。）
        tr.Translate(0.01f, 0, 0);
    }
}
