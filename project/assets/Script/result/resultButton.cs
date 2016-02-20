using UnityEngine;
using System.Collections;

public class resultButton : MonoBehaviour {

    /// ボタンをクリックした時の処理
    public void OnClick()
    {
        sceneManager.NextScene("Title");
    }
}

