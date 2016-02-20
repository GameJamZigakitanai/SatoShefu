using UnityEngine;
using System.Collections;
using UnityEngine.UI;  ////ここを追加////

public class reviewText : MonoBehaviour {

    // 講評の表示
    //--------------------------------------------------------------------
    void OnEnable()
    {
        int score = result.Instance.Score;

        //講評一覧を表示
        //（くそまずい）
        if(score < 100)
        {
            this.GetComponent<Text>().text = "講評：くそまずい！！\n"
                +"今まで食べた\nカレーの中で\n一番まずい！";
        }
        //(まずい）
        else if (score < 200)
        {
            this.GetComponent<Text>().text = "講評：まずい！\n"
                + "こんなカレーを\n出すなんて\n信じられない！";
        }
        //(おいしくない）
        else if (score < 300)
        {
            this.GetComponent<Text>().text = "講評：おいしくない\n"
                + "期待していた味と\n全然違う";
        }
        //(ふつう）
        else if (score < 400)
        {
            this.GetComponent<Text>().text = "講評：普通\n"
                + "レトルトカレーと\nいい勝負";
        }
        //(おいしい）
        else if (score < 500)
        {
            this.GetComponent<Text>().text = "講評：おいしい\n"
                + "このカレーなら\n毎日食べたい！";
        }
        //(超美味しい）
        else if (score < 600)
        {
            this.GetComponent<Text>().text = "講評：超美味しい\n"
                + "今まで食べた\nカレーの中で\n一番美味しい！";
        }
        //(神）
        else
        {
            this.GetComponent<Text>().text = "講評：神\n"
                + "神だわ……\n佐藤シェフは神";
        }
    }
}
