using UnityEngine;
using System.Collections;

public class zairyouIsMatchRule : MonoBehaviour {

	// メンバ変数
	//--------------------------------------------------------------------
	private zairyouFactory factory;

	// プロパティ
	//--------------------------------------------------------------------
	public zairyouFactory Factory { set { factory = value; } }

	// @brief  : オブジェクト生成時
	//--------------------------------------------------------------------
	void Awake()
	{
		GetComponent<zairyou>().ISRule = true;
	}

	// @brief  : オブジェクト削除時
	//--------------------------------------------------------------------
	void OnDestroy()
	{
		if (factory)
		{
			factory.OnDestroyRuleZairyou();
        }
	}
}
