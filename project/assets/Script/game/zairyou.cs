using UnityEngine;
using System.Collections;

public class zairyou : MonoBehaviour {

	// メンバ変数
	//--------------------------------------------------------------------
	[SerializeField]
	private string[] tags;  // クリア条件タグ
	private rule     rule;  // ルール
	private bool     is_rule_true;	// ルール内に入っているか

	// プロパティ
	//--------------------------------------------------------------------
	public string[] Tags	// タグ
	{
		get { return tags; }
	}
	public int Score { get { return rule.CreateZairyouScore(this); } }
	public rule Rule { get { return rule; } set { rule = value; } }  // ルール
	public bool ISRule { get { return is_rule_true; } set { is_rule_true = value; } }
}
