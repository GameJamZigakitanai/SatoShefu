using UnityEngine;
using System.Collections;

public class tileFactory : MonoBehaviour
{

	// メンバ変数
	//--------------------------------------------------------------------
	[SerializeField]
	private float start_y;              // 初めの高さ
	[SerializeField]
	private int width_tile;             // 横タイル数
	[SerializeField]
	private int height_tile;            // 縦タイル数
	[SerializeField]
	private float margin_tile_to_tile;  // タイルとタイルの間の幅
	[SerializeField]
	private GameObject prefab;          // タイルのプレハブ

	private float bottom;          // 最下

	private int numberOfTiles;

	// プロパティ
	//--------------------------------------------------------------------
	public float Bottom{get{return bottom;}}

	// @brief  : 初期化
	//--------------------------------------------------------------------
	void Start()
	{
		numberOfTiles = 0;
		// 画面の座標を取得する
		Rect screen;
		{
			var camera = Camera.main;
			Vector2 left_bottom  = camera.ViewportToWorldPoint(Vector3.zero);
			Vector2 right_top = camera.ViewportToWorldPoint(Vector3.one);
            Vector2 screen_size = new Vector2(right_top.x-left_bottom.x,left_bottom.y - right_top.y);

			screen = new Rect(new Vector2(left_bottom.x,right_top.y), screen_size);
		}

		// タイルの大きさを作る
		Vector2 size;
		{
			var sprite = prefab.gameObject.GetComponent<SpriteRenderer>();
			var rect = sprite.bounds;
			size.x = rect.size.x;
			size.y = rect.size.y;
		}

		Vector2 init_pos = new Vector2();
		init_pos.x = margin_tile_to_tile + screen.x + size.x * 0.5f;
		init_pos.y = screen.y - margin_tile_to_tile - start_y - size.y * 0.5f;
        Vector2 pos = new Vector2(init_pos.x,init_pos.y);

		// 左上から生成していく
		for (int y = 0; y < height_tile; ++y)
		{
			for (int x = 0; x < width_tile; ++x)
			{
				Create(pos);
				//Debug.Log (numberOfTiles);
				pos.x += size.x + margin_tile_to_tile;
			}
			pos.y -= size.y + margin_tile_to_tile;
			pos.x  = init_pos.x;
		}

		bottom = pos.y;
			
		// 役割が終わったので消える
		Destroy(this);
	}

	// @brief  : タイルを生成する
	// @param  : 位置
	//--------------------------------------------------------------------
	public void Create(Vector2 _pos)
	{
		GameObject new_tile = GameObject.Instantiate(prefab);
		tileItem temp = new_tile.GetComponent<tileItem>();
		temp.number = numberOfTiles;
		int tempNum = Random.Range (0, InputManager.ingredients.Length-1);
		//Debug.Log (tempNum);
		temp.tag = InputManager.ingredients[tempNum];
		temp.GetComponent<SpriteRenderer> ().sprite = Resources.Load("ingredients/"+InputManager.ingredients[tempNum], typeof(Sprite)) as Sprite;
		numberOfTiles = numberOfTiles + 1;
		new_tile.transform.parent = this.transform;
		new_tile.transform.position = _pos;
	}

	/*
	private void CreateNabe(Vector2 _pos)
	{
		var new_tile = GameObject.Instantiate(nabe);
		new_tile.transform.parent = this.transform;
		new_tile.transform.position = _pos;
	}
	*/
}
