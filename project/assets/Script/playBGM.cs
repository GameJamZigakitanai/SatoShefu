using UnityEngine;

public class playBGM : MonoBehaviour {

	// メンバ変数
    //--------------------------------------------------------------------
    public AudioClip clip;      // 鳴らしたいBGM
    public float     pitch;     // ピッチ
    private BGM      bgm;       // 作成されたbgm

	// @brief  : シーン開始時
    //--------------------------------------------------------------------  
	void Awake ()
    {
	   bgm = audioManager.LoadBGM(clip,pitch);
	}

	// @brief  : 再生
    //--------------------------------------------------------------------
    public void Play()
    {
        //Debug.Log("Play " +bgm.name);
        bgm.Play();
    }

	// @brief  : フェードアウト
    //--------------------------------------------------------------------
    public void FadeOut()
    {
        bgm.FadeOut();
    }

	// @brief  : フェードイン
    //--------------------------------------------------------------------
    public void FadeIn()
    {
        bgm.FadeIn();
    }
}
