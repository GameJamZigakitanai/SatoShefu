using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class nabe : MonoBehaviour {

    // メンバ変数
    //--------------------------------------------------------------------
    [SerializeField]
    // 鍋に入れた材料の配列（ゲームオブジェクトで持つ）
    private List<GameObject> zairyous = new List<GameObject>();

    // 初期化
    //--------------------------------------------------------------------
    void Start () {
	
	}

    // update
    //--------------------------------------------------------------------
    void Update () {
	
	}

    // 材料を入れ込む処理
    //--------------------------------------------------------------------
    void InsertZairyou(GameObject gobj)
    {
        // 衝突したオブジェクトを追加する
        zairyous.Add(gobj);
        // 材料を追加したことを通知する処理
        // TODO SendMessage("");
    }
}
