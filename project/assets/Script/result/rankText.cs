using UnityEngine;
using System.Collections;
using UnityEngine.UI;  ////ここを追加////

public class rankText : MonoBehaviour {
    // ランクの表示
    //--------------------------------------------------------------------
    void OnEnable()
    {
        int score = result.Instance.Score;

        //講評一覧を表示
        //（くそまずい:E）
        if (score < 100)
        {
            this.GetComponent<Text>().text = "F";
        }
        //(まずい）
        else if (score < 200)
        {
            this.GetComponent<Text>().text = "E";
        }
        //(おいしくない）
        else if (score < 300)
        {
            this.GetComponent<Text>().text = "D";
        }
        //(ふつう）
        else if (score < 400)
        {
            this.GetComponent<Text>().text = "C";
        }
        //(おいしい）
        else if (score < 500)
        {
            this.GetComponent<Text>().text = "B";
        }
        //(超美味しい）
        else if (score < 600)
        {
            this.GetComponent<Text>().text = "A";
        }
        //(神）
        else
        {
            this.GetComponent<Text>().text = "S";
        }
    }
}
