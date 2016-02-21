using UnityEngine;
using System.Collections;

public class scene : MonoBehaviour {

	// メンバ変数
	//---------------------------------------------------------------
	[SerializeField]
	private playBGM bgm;

	// @brief  : 初期化
	//---------------------------------------------------------------
	void Start ()
	{
		bgm.Play();
	}
}
