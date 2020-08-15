using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

public class Story1 : MonoBehaviour 
{
	[SerializeField]UnityEngine.UI.Text textbox, Yuname, Lilianame;
	[SerializeField]SpriteRenderer Lilia, Yu, YuTag, LiliaTag;

	[SerializeField] SpriteAtlas atlas;

	IEnumerator Start () 
	{
		textbox.text = "私、リリアっていうの。";
        Lilianame.text = "リリア";
		Lilia.sprite = atlas.GetSprite("StoryLilia");
		Yu.sprite = atlas.GetSprite("StoryYu2");
        LiliaTag.sprite = atlas.GetSprite("LiliaTag");
		yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
		yield return null;

        textbox.text = "僕はユウっていうんだ。";
        Yuname.text = "ユウ";
		Lilia.sprite = atlas.GetSprite("StoryLilia2");
		Yu.sprite = atlas.GetSprite("StoryYu");
        LiliaTag.sprite = atlas.GetSprite("LiliaTag2");
        YuTag.sprite = atlas.GetSprite("YuTag");
		yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
		yield return null;

        textbox.text = "やっと見つけたわよユウくん。";
        Lilianame.text = "リリア";
		Lilia.sprite = atlas.GetSprite("StoryLilia");
		Yu.sprite = atlas.GetSprite("StoryYu2");
        LiliaTag.sprite = atlas.GetSprite("LiliaTag");
        YuTag.sprite = atlas.GetSprite("YuTag2");
		yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
		yield return null;

        textbox.text = "あはは、つかまっちゃった。";
        Yuname.text = "ユウ";
		Lilia.sprite = atlas.GetSprite("StoryLilia2");
		Yu.sprite = atlas.GetSprite("StoryYu");
        LiliaTag.sprite = atlas.GetSprite("LiliaTag2");
        YuTag.sprite = atlas.GetSprite("YuTag");
		yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
		yield return null;
	}
}