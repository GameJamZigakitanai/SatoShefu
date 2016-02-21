using UnityEngine;

public class playSE : MonoBehaviour {

    // メンバ変数
    //--------------------------------------------------------------------
    public  AudioClip clip;           // 鳴らしたいSE
    public  float     pitch = 1.0f;   // ピッチ
    private SE        se;             // 鳴らす本体

	// プロパティ
	//--------------------------------------------------------------------
	public string ClipName { get { return clip.name; } }

	// @brief  : シーン開始時
	//--------------------------------------------------------------------
	void Awake()
    {
        se = audioManager.LoadSE(clip,pitch);
    }

    // @brief  : 鳴らす
    //--------------------------------------------------------------------
    public void Play()
    {
        //Debug.Log("Play " + se.name);
        se.Play();
    }

    // @brief  : 壊れたら止まる
    //--------------------------------------------------------------------
    void OnDestroy()
    {
        if(se) se.Stop();
    }
}
