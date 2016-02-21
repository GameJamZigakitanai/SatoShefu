﻿using UnityEngine;
using UnityEngine.UI;

public class limitNabeHaveZairyou : MonoBehaviour {

	// メンバ変数
	//--------------------------------------------------------------------
	[SerializeField]
	private int max_have;   // 最大数量
	[SerializeField]
	private int min_have;   // 最小数量

	private int now_wait_limit;	// 今回のリミット

	// プロパティ
	//--------------------------------------------------------------------
	public int Limit { get { return now_wait_limit; } }

	// @brief  : 初期化
	//--------------------------------------------------------------------
	void Awake()
	{
		// 今回のリミットを作成
		now_wait_limit = Random.Range(min_have, max_have);

		// テキストに追加
		var text = GetComponent<Text>();
		text.text = now_wait_limit.ToString();
	}

	// @brief  : 残りを減らす
	//--------------------------------------------------------------------
	public void Dec() { --now_wait_limit; }
}
