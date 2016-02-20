using UnityEngine;

/******************************************************************************
|   プレイ回数
*-----------------------------------------------------------------------------*/
public static class PlayCount {

    // メンバ変数
    //--------------------------------------------------------------------
    public const string KEY  = "PLAY_COUNT";

    // プロパティ
    //--------------------------------------------------------------------
    public static int Count
    {
        get
        {
            return PlayerPrefs.GetInt(KEY,0);
        }
        set
        {
            PlayerPrefs.SetInt(KEY,value);
        }
    }
    public static bool IsNewPlay   // 初プレイか
    {
        get
        {
            return PlayerPrefs.GetInt(KEY,0) <= 0;
        }
    }
}
