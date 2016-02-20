using UnityEngine;
using System.Collections;

public class titleButton : MonoBehaviour
{
    /// ボタンをクリックした時の処理
    public void OnClick()
    {
        //スコアの初期化
        result.Instance.initScore();
        //シーン遷移
        sceneManager.NextScene("Game");
    }
}

