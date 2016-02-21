using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class nabe : MonoBehaviour {

	// メンバ変数
	//--------------------------------------------------------------------
	[SerializeField]
	private limitNabeHaveZairyou limit; // リミット

	private List<zairyou> zairyou;

	// @brief  : 初期化
	//--------------------------------------------------------------------
	void Awake()
	{
		result.Instance.ResetOnGame();
		zairyou = new List<zairyou>();
	}

	// @brief  : 材料が入ったなら
	//         : zairyou
	//--------------------------------------------------------------------
	public void DropZairyou(GameObject _zairyou)
	{
		if (limit.IsEnd) return;
		_zairyou.SetActive(false);
		_zairyou.transform.parent = transform;
		zairyou.Add(_zairyou.GetComponent<zairyou>());
		_zairyou.SetActive(false);
        limit.Dec();

		if (limit.IsEnd)
		{
			Debug.Log(zairyou.Count);
			int score = 0;
			result.ZAIRYO[] data = new result.ZAIRYO[zairyou.Count];

			for (int i=0; i < zairyou.Count; ++i)
			{
				// スコア計算
				score = zairyou[i].Score;

				// 材料リストの作成
				data[i].is_rule = zairyou[i].ISRule;
				data[i].sprite = zairyou[i].gameObject.GetComponent<SpriteRenderer>().sprite;
			}

			// Set
			result.Instance.SetOnEndGame(score, data);

			sceneManager.NextScene("Result");
		}
	}
}
