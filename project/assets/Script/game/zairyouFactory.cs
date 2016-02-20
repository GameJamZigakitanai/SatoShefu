using UnityEngine;
using System.Collections;

public class zairyouFactory : MonoBehaviour {

	// メンバ変数
	//--------------------------------------------------------------------
	[SerializeField]
	private int   min_rule_zairyou;		// ルールと同じ材料は最低何個出すか

	[SerializeField]
	private GameObject[] zairyous;		// 材料たち

	private rule clear_rule;			// 条件クラス
	private int  rule_zairyou_count;	// ルールに沿った材料の数

	// @brief  : 初期化
	//--------------------------------------------------------------------
	void OnEnable ()
	{
		// 条件コンポーネントの取得
		clear_rule = GetComponent<rule>();

		// ルールに沿った材料の数分だけ先に作成
	}

	//// @brief  : ルールに沿ったオブジェクトの生成
	////--------------------------------------------------------------------
	//public GameObject CreateRule()
	//{
	//}
}
