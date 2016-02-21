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
        if (score < result.SCORERANKS[0])
        {
            this.GetComponent<Text>().text = "F";
        }
        //(まずい）
        else if (score < result.SCORERANKS[1])
        {
            this.GetComponent<Text>().text = "E";
        }
        //(おいしくない）
        else if (score < result.SCORERANKS[2])
        {
            this.GetComponent<Text>().text = "D";
        }
        //(ふつう）
        else if (score < result.SCORERANKS[3])
        {
            this.GetComponent<Text>().text = "C";
        }
        //(おいしい）
        else if (score < result.SCORERANKS[4])
        {
            this.GetComponent<Text>().text = "B";
        }
        //(超美味しい）
        else if (score < result.SCORERANKS[5])
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
