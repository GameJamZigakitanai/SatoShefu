using UnityEngine;
using System.Collections;

public class zairyou : MonoBehaviour {

	// メンバ変数
	//--------------------------------------------------------------------
	[SerializeField]
	private string[] tags;  // クリア条件タグ
	private rule     rule;	// ルール

	// プロパティ
	//--------------------------------------------------------------------
	public string[] Tags	// タグ
	{
		get { return tags; }
	}
	public int Score { get { return rule.CreateZairyouScore(this); } }
	public rule Rule { get { return rule;} set { rule = value; } }  // ルール
}
