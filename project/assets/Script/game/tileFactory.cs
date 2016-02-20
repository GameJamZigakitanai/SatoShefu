using UnityEngine;
using System.Collections;

public class tileFactory : MonoBehaviour
{

	// メンバ変数
	//--------------------------------------------------------------------
	[SerializeField]
	private int width_tile;             // 横タイル数
	[SerializeField]
	private int height_tile;            // 縦タイル数
	[SerializeField]
	private float margin_tile_to_tile;  // タイルとタイルの間の幅
	[SerializeField]
	private GameObject prefab;          // タイルのプレハブ

	// @brief  : 初期化
	//--------------------------------------------------------------------
	void Awake()
	{
		// タイルの大きさを取得する
		Vector2 size;
		{
			var sprite = prefab.gameObject.GetComponent<SpriteRenderer>();
			var rect = sprite.sprite.rect;
			size.x = rect.width;
			size.y = rect.height;
		}

		Vector2 init_pos = new Vector2(size.x * 0.5f + margin_tile_to_tile, size.y * 0.5f + margin_tile_to_tile);
		Vector2 pos = new Vector2(init_pos.x,init_pos.y);

		// 左上から生成していく
		for (int y = 0; y < height_tile; ++y)
		{
			for (int x = 0; x < width_tile; ++x)
			{
				Create(pos);
				pos.x += size.x + margin_tile_to_tile;
			}
			pos.y -= size.y + margin_tile_to_tile;
			pos.x  = init_pos.x;
		}

		// 役割が終わったので消える
		Destroy(this);
	}

	// @brief  : タイルを生成する
	// @param  : 位置
	//--------------------------------------------------------------------
	private void Create(Vector2 _pos)
	{
		var new_tile = GameObject.Instantiate(prefab);
		new_tile.transform.parent = this.transform;
		new_tile.transform.localPosition = _pos;
	}
}
