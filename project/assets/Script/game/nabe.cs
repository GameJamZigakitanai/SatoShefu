using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class nabe : MonoBehaviour {

	// メンバ変数
	//--------------------------------------------------------------------
	[SerializeField]
	private limitNabeHaveZairyou limit; // リミット

	// @brief  : 材料が入ったなら
	//         : zairyou
	//--------------------------------------------------------------------
	public void DropZairyou(GameObject _zairyou)
	{
		if (limit.IsEnd) return;
		_zairyou.SetActive(false);
		_zairyou.transform.parent = transform;
		limit.Dec();
		if (limit.IsEnd) sceneManager.NextScene("Result");
	}
}
