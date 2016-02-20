using UnityEngine;
using UnityEngine.UI;

public class ruleText : MonoBehaviour {

	// メンバ変数
	//--------------------------------------------------------------------
	private Text text;  // テキスト

	// プロパティ
	//--------------------------------------------------------------------
	public string Txt
	{
		get { return text.text; }
		set { text.text = value; }
	}

	// @brief  : 初期化
	//--------------------------------------------------------------------
	void Awake ()
	{
		text = GetComponent<Text>();
	}
}
