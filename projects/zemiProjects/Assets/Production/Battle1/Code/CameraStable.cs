using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStable : MonoBehaviour {
    private Camera cam;
    private float width = 1125.0f;
    private float height = 2436.0f;
    private float pixelPerUnit = 200f;

    void Start () {
        float aspect = (float) Screen.height / (float) Screen.width; //表示画面のアスペクト比
        float bgAcpect = height / width; //理想とするアスペクト比

        // カメラコンポーネントを取得
        cam = GetComponent<Camera> ();

        // カメラのorthographicSizeを設定
        cam.orthographicSize = (height / 2f / pixelPerUnit);

        //画面が縦に長い
        //想定しているアスペクト比とどれだけ差があるかを出す
        float bgScale = aspect / bgAcpect;

        // カメラのorthographicSizeを縦の長さに合わせて設定しなおす
        cam.orthographicSize *= bgScale;

        // viewportRectを設定
        cam.rect = new Rect (0f, 0f, 1f, 1f);
    }
}