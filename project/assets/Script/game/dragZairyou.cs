using UnityEngine;
using System.Collections;

public class dragZairyou : MonoBehaviour
{
	// メンバ変数
	//--------------------------------------------------------------------
	private Vector3        pos_old;    // タイルにいたときの位置
	private zairyouFactory zairyou;     // 材料ファクトリ
	private tileFactory    tile;        // タイルファクトリ
	private nabe			nabe;		// 鍋

	// プロパティ
	//--------------------------------------------------------------------
	public zairyouFactory Zairyou { set { zairyou = value; } }
	public tileFactory Tile { set { tile = value; } }
	public nabe Nabe { set { nabe = value; } }

	// @brief  : 初期化
	//--------------------------------------------------------------------
	void Awake()
	{
		pos_old = new Vector3();
		pos_old = transform.position;
	}

	// @brief  : ドロップ時
	//--------------------------------------------------------------------
	public void OnDrop()
	{
		// 鍋に入るか
		if (transform.position.y < tile.Bottom)
		{
			gameObject.transform.parent = nabe.transform;
			var new_zairyou = zairyou.Create();
			new_zairyou.transform.position = pos_old;
		}

		// 入らないなら元の位置に戻る
		else
		{
			gameObject.transform.position = pos_old;
		}
		Destroy(this);
	}
}