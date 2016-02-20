using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class number : MonoBehaviour {

	// メンバ変数
    //--------------------------------------------------------------------
    public Sprite[] sprite;     // テクスチャ

#if DEBUG   
	// @brief  : 初期化
    //--------------------------------------------------------------------
    void Awake()
    {
        if(sprite.Length != 10)
        {
            Debug.LogError("テクスチャ数があっていません");
            Debug.Break();
        }
    }
#endif
    
	// @brief  : 数字の変更
    //--------------------------------------------------------------------
    public void Set( int num )
    {
#if DEBUG
        if( num < 0 || 10 <= num )
        {
            Debug.LogError("数字は0以上10未満でなければなりません");
        }
#endif

        // 表示
        GetComponent<Image>().sprite = sprite[num];
    }
}
