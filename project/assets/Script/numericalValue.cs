using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class numericalValue : MonoBehaviour {

	// メンバ変数
    //--------------------------------------------------------------------
    public bool       isDrawZero;       // 余った桁に0を描画するか
    private int       maskNumber;       // マスク用

	// @brief  : 初期化
    //--------------------------------------------------------------------
    void Awake()
    {
        // 桁数分オブジェクトを探す
        // isDrawZeroなら描画しない
        number[] numberScript = gameObject.GetComponentsInChildren<number>();
        #if DEBUG
        if(!numberScript[0]) Debug.LogError("numberScriptがありません");
        #endif // DEBUG

        // マスク用の数値を作成
        maskNumber = (int)Mathf.Pow( 10.0f, numberScript.Length );
        
        // 桁表示
        Set(0);
    }
    
    // @brief  : 桁表示
    //--------------------------------------------------------------------
    public void Set(int num)
    {
        number[] numberScript = gameObject.GetComponentsInChildren<number>();
        #if DEBUG
        if(!numberScript[0]) Debug.LogError("numberScriptがありません");
        #endif // DEBUG
        
        // マスク
        int mask  = maskNumber;
        
        // 桁を越えたらカンスト表示
        if( num > mask )
        {
            foreach( var i in numberScript )
            {
                i.enabled = true;
                i.Set(9);
            }
            return;
        }
        mask /= 10;

        // 各桁の数字を取り出し、子に適用
        bool isDraw = false;    // 一度でも描画したのか
        foreach( var i  in numberScript )
        {
            // 描画する数字を取り出す
            int draw  = num / mask ;
                        
            // 大きい桁を0で埋めない場合は、その部分を描画しない
            bool isNotDraw = draw <= 0 && !isDraw && !isDrawZero;
            if(isNotDraw)
            {
                i.gameObject.SetActive(false);
            }
            else    // 普通は描画する
            {
                i.gameObject.SetActive(true);
                i.Set(draw);
                isDraw = true;
            }
            
            // 次の桁へ
            num %= mask;
            mask /= 10;
        }
        
        // 一度も描画していなければ0だけ描画する
        if(!isDraw)
        {
            numberScript[(numberScript.Length-1)].gameObject.SetActive(true);
            numberScript[(numberScript.Length-1)].Set(0);
        }
    }
}
