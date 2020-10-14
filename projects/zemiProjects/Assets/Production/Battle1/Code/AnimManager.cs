using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
===== AnimManager =====
アニメーションが組まれているPrefabを適宜呼び出して、
超超超初心者でもアニメーションを擬似的に好きなタイミングで呼び出せるようにしようじゃないかっていう魂胆デス。

===== 使い方 =====
アニメーション１つにつき、１つの関数を作ります。
コードは１行だけでいいです。下にテンプレートあるので、それをコピペして使ってください。
後は、アニメーションを再生したいところで
AnimManager.Instance.関数の名前(); ってやればおｋなはずです。

===== 下準備 =====
Prefabの生成方法は、授業でやったと思うので省略します。（わかんなかったらClassroomのドライブの中にあると思います）
Prefab側の設定としては、
オブジェクトにアニメーションを割り当てて、start関数にアニメーションを再生するコードを付けてあげるだけでおｋです。

===== テンプレ =====
void 関数の名前（なんのアニメーションかわかるやつにしてね）(){
    Instantiate(生成するPrefabの名前, new Vector3(位置X軸, 位置y軸, 0.0f), Quaternion.identity);
}

半角のカッコは消したら関数って認識しなくなるので消さないでくださいね。

初版・10/12　萩原
*/

public class AnimManager : SingletonMonoBehaviour<AnimManager>
{
    public GameObject stprefab;

    void Gamestart()
    {
        Instantiate(stprefab, new Vector3(0.1f, 1.95f, 0.0f), Quaternion.identity);
    }
}
