using UnityEngine;
using System.Collections;

public class rule : MonoBehaviour {

	// クリア条件
	//--------------------------------------------------------------------
	public struct RULE
	{
		public string tag;
		public int score;
	};

	// メンバ変数
	//--------------------------------------------------------------------
	[SerializeField]
	private string[] tagList;     // ルールリスト
	[SerializeField]
	private int      mainScore;   // メインスコア
	[SerializeField]
	private int[]    subScore;    // サブスコア(配列数 = サブ条件数)
 
	private RULE   main; // 必須条件
	private RULE[] sub;  // その他

	// プロパティ
	//--------------------------------------------------------------------
	public string   Main { get { return main.tag; } }
	public string[] Sub
	{
		get
		{
			string[] re = new string[sub.Length];
			for (int i=0; i < sub.Length; ++i)
			{
				re[i] = sub[i].tag;
			}
			return re;
		}
	}

	// @brief  : 初期化
	//--------------------------------------------------------------------
	void Awake ()
	{
		// メインルールの生成
		main = CreateRule(mainScore);

		// サブルールの生成
		sub = new RULE[subScore.Length];
		for (int i = 0; i < subScore.Length; ++i)
		{
			// サブルールは被ってはいけない
			bool is_clear = false;
			while (is_clear)
			{
				sub[i] = CreateRule(subScore[i]);
				if (IsUnique(sub[i].tag)) is_clear = true;
			}
		}
	}

	// @brief  : 材料のタグリストからスコアを生成する
	// @param  : 材料
	// @return : スコア
	//--------------------------------------------------------------------
	public int CreateZairyouScore(zairyou _zairyou)
	{
		int re = 0;

		// 条件の確認
		for(var i = 0; i < _zairyou.Tags.Length; ++i)
		{
			// メイン
			if (_zairyou.Tags[i] == main.tag) re += main.score;

			// サブ
			foreach (var j in sub)
			{
				if (_zairyou.Tags[i] == j.tag) re += j.score;
			}
		}

		return re;
    }

	// @brief  : 条件の生成
	// @param  : スコア
	//--------------------------------------------------------------------
	private RULE CreateRule(int _score)
	{
		RULE re;
		re.tag   = tagList[Random.Range(0, tagList.Length)];
		re.score = _score;
		return re;
	}

	// @brief  : 指定したルールが設定上被っていないか
	// @param  : かぶっていない(true),かぶっている(false)
	//--------------------------------------------------------------------
	private bool IsUnique(string _tag)
	{
		// メインルールがかぶっていないか？
		if (main.tag == _tag) return false;

		// サブルールがかぶっていないか
		for (int i = 0; i < sub.Length; ++i)
		{
			if (sub[i].tag == _tag) return false;
		}

		return true;
	}
}
