using UnityEngine;
using System.Collections;
using UnityEngine.UI;  ////ここを追加////

public class scoreText : MonoBehaviour {

    // スコアの表示
    //--------------------------------------------------------------------
    void OnEnable () {
        this.GetComponent<Text>().text = "Score:" + result.Instance.Score;
    }
}
