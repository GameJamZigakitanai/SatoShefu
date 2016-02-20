using UnityEngine;
using System.Collections;

public class zairyou : MonoBehaviour {

	// メンバ変数
	//--------------------------------------------------------------------
	[SerializeField]
	private string[] tags;	// クリア条件タグ

	// プロパティ
	//--------------------------------------------------------------------
	public string[] Tags
	{
		get { return tags; }
	}
}
