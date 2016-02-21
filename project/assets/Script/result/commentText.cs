using UnityEngine;
using System.Collections;
using UnityEngine.UI;  ////ここを追加////

public class commentText : MonoBehaviour
{

    // 評価の表示
    //--------------------------------------------------------------------
    void OnEnable()
    {
        int score = result.Instance.Score;

        //評価一覧を表示
        //（くそまずい）
        if (score < result.SCORERANKS[0])
        {
            this.GetComponent<Text>().text = "今まで食べた\nカレーの中で\n一番まずい！";
        }
        //(まずい）
        else if (score < result.SCORERANKS[1])
        {
            this.GetComponent<Text>().text = "こんなカレーを\n出すなんて\n信じられない！";
        }
        //(微妙）
        else if (score < result.SCORERANKS[2])
        {
            this.GetComponent<Text>().text = "期待していた味と\n全然違う";
        }
        //(ふつう）
        else if (score < result.SCORERANKS[3])
        {
            this.GetComponent<Text>().text = "レトルトカレーと\nいい勝負";
        }
        //(おいしい）
        else if (score < result.SCORERANKS[4])
        {
            this.GetComponent<Text>().text = "このカレーなら\n毎日食べたい！";
        }
        //(超美味しい）
        else if (score < result.SCORERANKS[5])
        {
            this.GetComponent<Text>().text = "今まで食べた\nカレーの中で\n一番美味しい！";
        }
        //(神）
        else
        {
            this.GetComponent<Text>().text = "神だわ……\n佐藤シェフは神";
        }
    }
}
