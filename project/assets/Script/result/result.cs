using UnityEngine;
using System.Collections;

using System;      //(for Array)
using System.Collections.ObjectModel;    //(for ReadOnlyCollection)

    public class result : TempSingletonMonoBehaviour<result>
{
	// 材料データ
	//--------------------------------------------------------------------
	public struct ZAIRYO
	{
		public bool   is_rule; // ルール通りか
		public Sprite sprite;	// スプライト
	}

	// メンバ変数
	//--------------------------------------------------------------------
	[SerializeField]
    private int score;			// スコア

	public ZAIRYO[] zairyo;    // 材料

    //スコアランクの点数
    public static readonly ReadOnlyCollection<int> SCORERANKS = Array.AsReadOnly(new int[] {
        10,    //以下ならくそまずい
        20,    //まずい
        40,    //微妙
        60,    //普通
        80,    //おいしい
        100    //超美味しい
    });

    // プロパティ
    //--------------------------------------------------------------------
    public int Score
    {
        get { return score; }
        set { this.score = value; }
    }

	// @brief  : 初期化
	//--------------------------------------------------------------------
	void Awake()
	{
		initScore();
		zairyo = new ZAIRYO[10];
	}

	// スコアの初期化
	//--------------------------------------------------------------------
	public void initScore()
    {
        score = 0;
    }

	// @brief  : 表示
	//--------------------------------------------------------------------
	//void OnGUI()
	//{
	//スコアを表示する
	//GUI.Label(new Rect(300, 10, 400, 100), "Score : " + score);
	//}

	// @brief  : ゲーム用リセット
	//--------------------------------------------------------------------
	public void ResetOnGame()
	{
		score = 0;
		zairyo.Initialize();
	}

	// @brief  : set
	//--------------------------------------------------------------------
	public void SetOnEndGame(int _score, ZAIRYO[] _zairyo)
	{
		score = _score;
		zairyo = new ZAIRYO[_zairyo.Length];
		for (int i =0; i<_zairyo.Length; ++i)
		{
			zairyo[i].is_rule = _zairyo[i].is_rule;
			zairyo[i].sprite = _zairyo[i].sprite;
		}
	}
}
