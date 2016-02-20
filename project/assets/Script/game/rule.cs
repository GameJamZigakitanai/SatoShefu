using UnityEngine;
using System.Collections.Generic;

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
	[SerializeField]
	private ruleText Text;    // テキスト

	private RULE   main; // 必須条件
	private RULE[] sub;  // その他
	private List<string> tag_not_used;     // そのタグはすでにルールで使用されていないもののリスト

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
		// ルールの数だけ初期化
		tag_not_used = new List<string>();
		foreach (var i in tagList)
		{
			tag_not_used.Add(i);
		}

		// メインルールの生成
		main = CreateRule(mainScore);

		// サブルールの生成
		sub = new RULE[subScore.Length];
		for (int i = 0; i < subScore.Length; ++i)
		{
			sub[i] = CreateRule(subScore[i]);
		}
	}

	// @brief  : 初期化
	//--------------------------------------------------------------------
	void Start()
	{
		// テキストの作成
		var text = new string(main.tag.ToCharArray());
		foreach (var i in sub)
		{
			text += i.tag;
		}
		text += " カレー";
		Text.Txt = text;
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
		RULE re = new RULE();

		int i          = Random.Range(0, tag_not_used.Count);
        re.tag         = tag_not_used[i];
        re.score       = _score;

		tag_not_used.Remove(re.tag);

		return re;
	}
}
