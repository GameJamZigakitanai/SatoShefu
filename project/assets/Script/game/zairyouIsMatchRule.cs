using UnityEngine;
using System.Collections;

public class zairyouIsMatchRule : MonoBehaviour {

	// メンバ変数
	//--------------------------------------------------------------------
	private zairyouFactory factory;

	// プロパティ
	//--------------------------------------------------------------------
	public zairyouFactory Factory { set { factory = value; } }

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
