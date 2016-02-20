using UnityEngine;
using System.Collections;

public class result : TempSingletonMonoBehaviour<result>
{
    // メンバ変数
    //--------------------------------------------------------------------
    [SerializeField]
    private int score;  // スコア

    // プロパティ
    //--------------------------------------------------------------------
    public int Score
    {
        get { return score; }
        set { this.score = value; }
    }

    // スコアの初期化
    //--------------------------------------------------------------------
    void initScore()
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
}
