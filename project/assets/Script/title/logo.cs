using UnityEngine;
using System.Collections;

public class logo : MonoBehaviour {

	// メンバ変数
	//--------------------------------------------------------------------
	public readonly float move_height = 0.4f;

	private float default_y;
	private float move;

	// @brief  : 初期化
	//--------------------------------------------------------------------
	void Awake()
	{
		default_y = transform.position.y;
		move = 0.0f;
	}

	// @brief  : 更新
	//--------------------------------------------------------------------
	void Update ()
	{
//		tra
	}
}
