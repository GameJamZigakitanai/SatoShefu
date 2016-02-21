using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class resultView : MonoBehaviour
{

    private float offset_x = 0.25f;
    private float offset_y = -4.25f;

    // @brief  : 表示
    //--------------------------------------------------------------------
    void Awake()
    {
        Debug.Log("result Start");
		//autoLayoutSetting();
        viewZairyous();
        viewShefu();
    }

	//// @brief  : オートレイアウトの調整
	////--------------------------------------------------------------------
	//void autoLayoutSetting()
	//{
	//	var rect = GetComponent<RectTransform>();
	//	var layout = GetComponent<GridLayoutGroup>();
	//	var cellSize = new Vector2();

	//	// 現在の横幅を取得する
	//	var width = rect.rect.width;
	//	cellSize.x = width / 5.0f;
	//	cellSize.y = cellSize.x;

	//	layout.cellSize = cellSize;
 //   }

	// @brief  : 鍋に入れた食材の表示
	//--------------------------------------------------------------------
	void viewZairyous()
    {
        // 画面の座標を取得する
        Rect screen;
        {
            var camera = Camera.main;
            Vector2 left_bottom = camera.ViewportToWorldPoint(Vector3.zero);
            Vector2 right_top = camera.ViewportToWorldPoint(Vector3.one);
            Vector2 screen_size = new Vector2(right_top.x - left_bottom.x, left_bottom.y - right_top.y);

            screen = new Rect(new Vector2(left_bottom.x, right_top.y), screen_size);
        }

        Debug.Log("zairyo length:" + result.Instance.zairyo.Length);

        // TODO:鍋に入っている材料の分だけ表示させる処理
        for (int i = 0; i < result.Instance.zairyo.Length; i++)
        {

            Debug.Log(result.Instance.zairyo[i].sprite);
            var gobj = new GameObject("入れた材料:" + i).AddComponent<Image>();
			gobj.rectTransform.SetParent(transform);
			gobj.rectTransform.localScale = new Vector2(1.0f, 1.0f);
			gobj.sprite = result.Instance.zairyo[i].sprite;


            //TODO 材料がルールにあっていなかったら×印をつける
            if (result.Instance.zairyo[i].is_rule == false)
            {
                var gobj2 = new GameObject("×").AddComponent<Image>();
				gobj2.rectTransform.SetParent(transform);
				gobj2.rectTransform.localScale = new Vector2(1.0f, 1.0f);
				gobj2.sprite = result.Instance.zairyo[0].sprite;
            }
        }
    }

    // @brief  : 佐藤シェフの表示
    //--------------------------------------------------------------------
    void viewShefu()
    {
        // 画面の座標を取得する
        Rect screen;
        {
            var camera = Camera.main;
            Vector2 left_bottom = camera.ViewportToWorldPoint(Vector3.zero);
            Vector2 right_top = camera.ViewportToWorldPoint(Vector3.one);
            Vector2 screen_size = new Vector2(right_top.x - left_bottom.x, left_bottom.y - right_top.y);

            screen = new Rect(new Vector2(left_bottom.x, right_top.y), screen_size);
        }

        //TODO スコアによって表示するシェフの画像を変更
        Sprite spriteImage;
        int score = result.Instance.Score;
        //（くそまずい:E）
        if (score < result.SCORERANKS[0])
        {
            spriteImage = Resources.Load("ingredients/きのこ", typeof(Sprite)) as Sprite;
        }
        //(まずい）
        else if (score < result.SCORERANKS[1])
        {
            spriteImage = Resources.Load("ingredients/きのこ", typeof(Sprite)) as Sprite;
        }
        //(おいしくない）
        else if (score < result.SCORERANKS[2])
        {
            spriteImage = Resources.Load("ingredients/きのこ", typeof(Sprite)) as Sprite;
        }
        //(ふつう）
        else if (score < result.SCORERANKS[3])
        {
            spriteImage = Resources.Load("ingredients/きのこ", typeof(Sprite)) as Sprite;
        }
        //(おいしい）
        else if (score < result.SCORERANKS[4])
        {
            spriteImage = Resources.Load("ingredients/きのこ", typeof(Sprite)) as Sprite;
        }
        //(超美味しい）
        else if (score < result.SCORERANKS[5])
        {
            spriteImage = Resources.Load("ingredients/きのこ", typeof(Sprite)) as Sprite;
        }
        //(神）
        else
        {
            spriteImage = Resources.Load("ingredients/きのこ", typeof(Sprite)) as Sprite;
        }


        SpriteRenderer gobj = new GameObject("シェフ").AddComponent<SpriteRenderer>();
        gobj.sprite = spriteImage;

        Vector2 init_pos = new Vector2();
        init_pos.x = offset_x * gobj.bounds.size.x + screen.x + gobj.bounds.size.x * 4.5f;
        init_pos.y = offset_y * gobj.bounds.size.y + screen.y - gobj.bounds.size.x * 4.0f;
        Vector3 pos = new Vector3(init_pos.x, init_pos.y, 1.0f);

        gobj.transform.position = pos;
        gobj.sortingOrder = 10;
    }

}