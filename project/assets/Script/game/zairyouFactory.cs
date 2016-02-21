using UnityEngine;
using System.Collections.Generic;

public class zairyouFactory : MonoBehaviour {

	// メンバ変数
	//--------------------------------------------------------------------
	[SerializeField]
	private int   min_rule_zairyou;		// ルールと同じ材料は最低何個出すか

	[SerializeField]
	private GameObject[] prefabs;		// 材料たち

	private rule clear_rule;				// 条件クラス
	private List<GameObject> rule_object;	// 条件に合ったオブジェクト
	private int  rule_zairyou_count;        // ルールに沿った材料が、いまある数

	// @brief  : 初期化
	//--------------------------------------------------------------------
	void Awake()
	{
		// 条件コンポーネントの取得
		clear_rule = GetComponent<rule>();

		rule_object = new List<GameObject>();

		enabled = false;
	}

	// @brief  : 初期化
	//--------------------------------------------------------------------
	void OnEnable ()
	{
		// ルールに沿った材料のリストを作成
		foreach (var i in prefabs)
		{
			var script = i.GetComponent<zairyou>();
			if (clear_rule.CheakIsScore(script)) rule_object.Add(i);
		}

		// タイルファクトリをenableにする
		GetComponent<tileFactory>().enabled = true;
    }

	// @brief  : 適当に作成
	//--------------------------------------------------------------------
	public GameObject Create()
	{
		// ルールに準じた材料が一定以下なら、ルールに沿ったオブジェクトを生成する
		if (rule_zairyou_count <= min_rule_zairyou) return CreateRule();

		var re = GameObject.Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
		re.GetComponent<zairyou>().Rule = clear_rule;
		for (int i = 0; i < rule_object.Count; ++i)
		{
			if (rule_object[i].GetType() == re.GetType())
            {
				++rule_zairyou_count;
				var match = re.AddComponent<zairyouIsMatchRule>();
				match.Factory = this;
				return re;
			}
        }
		return re;
	}

	// @brief  : ルールに沿った材料が消えたとき
	//--------------------------------------------------------------------
	public void OnDestroyRuleZairyou()
	{
		--rule_zairyou_count;
    }

	// @brief  : ルールに沿った材料の生成
	//--------------------------------------------------------------------
	private GameObject CreateRule()
	{
		var re = GameObject.Instantiate(rule_object[Random.Range(0, rule_object.Count)]);
		re.GetComponent<zairyou>().Rule = clear_rule;
		++rule_zairyou_count;
		var match = re.AddComponent<zairyouIsMatchRule>();
		match.Factory = this;
		return re;
	}
}
