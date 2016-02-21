﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;  ////ここを追加////

public class reviewText : MonoBehaviour {

    // 評価の表示
    //--------------------------------------------------------------------
    void OnEnable()
    {
        int score = result.Instance.Score;

        //評価一覧を表示
        //（くそまずい）
        if(score < result.SCORERANKS[0])
        {
            this.GetComponent<Text>().text = "評価：くそまずい";
        }
        //(まずい）
        else if (score < result.SCORERANKS[1])
        {
            this.GetComponent<Text>().text = "評価：まずい";
        }
        //(微妙）
        else if (score < result.SCORERANKS[2])
        {
            this.GetComponent<Text>().text = "評価：微妙";
        }
        //(ふつう）
        else if (score < result.SCORERANKS[3])
        {
            this.GetComponent<Text>().text = "評価：普通";
        }
        //(おいしい）
        else if (score < result.SCORERANKS[4])
        {
            this.GetComponent<Text>().text = "評価：美味しい";
        }
        //(超美味しい）
        else if (score < result.SCORERANKS[5])
        {
            this.GetComponent<Text>().text = "評価：超美味しい";
        }
        //(神）
        else
        {
            this.GetComponent<Text>().text = "評価：神";
        }
    }
}
