using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class nabe : MonoBehaviour {

	// メンバ変数
	//--------------------------------------------------------------------
	[SerializeField]
	private limitNabeHaveZairyou limit; // リミット

	// @brief  : 初期化
	//--------------------------------------------------------------------
	void Awake()
	{
		result.Instance.ResetOnGame();
	}

	// @brief  : 材料が入ったなら
	//         : zairyou
	//--------------------------------------------------------------------
	public void DropZairyou(GameObject _zairyou)
	{
		if (limit.IsEnd) return;
		_zairyou.SetActive(false);
		_zairyou.transform.parent = transform;
		limit.Dec();
		if (limit.IsEnd)
		{
			var zairyos = GetComponentsInChildren<zairyou>();
			int score = 0;
			result.ZAIRYO[] data = new result.ZAIRYO[zairyos.Length];

			for (int i=0; i < zairyos.Length; ++i)
			{
				// スコア計算
				score = zairyos[i].Score;

				// 材料リストの作成
				data[i].is_rule = zairyos[i].ISRule;
				data[i].sprite = zairyos[i].gameObject.GetComponent<SpriteRenderer>().sprite;
			}

			// Set
			result.Instance.SetOnEndGame(score, data);

			sceneManager.NextScene("Result");
		}
	}
}
