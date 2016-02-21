using UnityEngine;
using System.Collections.Generic;


/******************************************************************************
|   BGM再生用クラス
*-----------------------------------------------------------------------------*/
public class BGM
{
    // 列挙体
    //--------------------------------------------------------------------
    internal enum STATE
    {
        PLAY,
        FADE_OUT,
        STOP,
        FADE_IN
    }

    // メンバ変数
    //--------------------------------------------------------------------
	private AudioSource source;     // ソース
    private STATE state = STATE.STOP;            // 現在のステータス

    public  string name             // 名前
    {
        get
        {
            return source.clip.name;
        }
    }
    public float volume             // ボリューム
    {
        set
        {
            source.volume = value;
        }
        get
        {
            return source.volume;
        }
    }
    internal STATE State
    {
        get
        {
            return state;
        }
    }

    // @brief  : bool オーバーライド
    //--------------------------------------------------------------------
    public static bool operator true ( BGM bgm )
    {
        if(!bgm.source) return false;
        return bgm.source == true;
    }
    public static bool operator false ( BGM bgm )
    {
        if(!bgm.source)return false;
        return bgm.source == false;
    }

    // @brief  : 再生
    //--------------------------------------------------------------------
    public void Play()
    {
        if(!source) return;
        if(state == STATE.PLAY) return;
        volume = 1.0f;
        if(state != STATE.FADE_IN) source.Play();
        state = STATE.PLAY;
    }

    // @brief  : 停止
    //--------------------------------------------------------------------
    public void Stop()
    {
        if(!source) return;
        if(source.isPlaying) source.Stop();
        state = STATE.STOP;
        volume = 0.0f;
    }

    // @brief  : フェードイン
    //--------------------------------------------------------------------
    public void FadeIn()
    {
        if(!source) return;
        volume = 0.0f;
        source.Play();
        state  = STATE.FADE_IN;
        audioManager.Instance.enabled = true;
    }

    // @brief  : フェードアウト
    //--------------------------------------------------------------------
    public void FadeOut()
    {
        if(!source) return;
        state = STATE.FADE_OUT;
        audioManager.Instance.enabled = true;
    }

    // @brief  : コンストラクタ
    // @param  : 名前
    //         : ソース
    //--------------------------------------------------------------------
    internal BGM( AudioSource _source )
    {
        source = _source;
        source.Stop();
        volume = 0.0f;
    }
};


/******************************************************************************
|   SE再生用クラス
*-----------------------------------------------------------------------------*/
public class SE
{
    // メンバ変数
    //--------------------------------------------------------------------
	private  AudioSource source;     // ソース
    public  string name
    {
        get
        {
            return source.clip.name;
        }
    }

    // @brief  : bool オーバーライド
    //--------------------------------------------------------------------
    public static bool operator true ( SE se )
    {
        if(!se.source) return false;
        return se.source == true;
    }
    public static bool operator false ( SE se )
    {
        if(!se.source) return false;
        return se.source == false;
    }

    // @brief  : 再生
    //--------------------------------------------------------------------
    public void Play()
    {
        Debug.Log(name + " is Play");
        if(!source) return;
        source.enabled = true;
        source.volume = 1.0f;
        source.Play();
    }

    // @brief  : 停止
    //--------------------------------------------------------------------
    public void Stop()
    {
        if(!source) return;
        if(source.isPlaying) source.Stop();
        source.volume = 0.0f;
        source.enabled = false;
    }
   
    // @brief  : コンストラクタ
    // @param  : 名前
    //         : ソース
    //--------------------------------------------------------------------
    internal SE( AudioSource _source )
    {
        source = _source;
        source.volume = 0.0f;
        source.enabled = false;
    }
};


/******************************************************************************
|   マネージャクラス
*-----------------------------------------------------------------------------*/
public class audioManager : TempSingletonMonoBehaviour<audioManager> {

    // メンバ変数
    //--------------------------------------------------------------------
    private List<SE>  seList  = new List<SE>();     // 効果音リスト
    private List<BGM> bgmList = new List<BGM>();    // BGMリスト


    // @brief  : シーン開始時の初期化
    //--------------------------------------------------------------------
    void Awake()
    {
        // AudioListenorの作成
        if(!FindObjectOfType(typeof(AudioListener))) gameObject.AddComponent<AudioListener>();

        // Updateは切る
        enabled = false;

        // オブジェクトは消えない
        DontDestroyOnLoad(gameObject);
    }

    // @brief  : 更新
    //--------------------------------------------------------------------    
	void Update ()
	{
        bool isEnable = false;
        foreach( var i in bgmList )
        {
            switch(i.State)
            {
            case BGM.STATE.FADE_IN:
                isEnable = true;
                FadeInBGM(i);
                break;
                
            case BGM.STATE.FADE_OUT:
                isEnable = true;
                FadeOutBGM(i);
                break;
                
            default:
                break;
            }
        }
        if(!isEnable) enabled = false;
	}

    // @brief  : SE読み込み
    // @param  : クリップ名
    //         : クリップデータ
    // @return : 再生用クラス
    //--------------------------------------------------------------------    
    public static SE LoadSE(AudioClip clip, float pitch = 1.0f)
    {
        if(!Instance) return null;
        return Instance.LoadSoundEffect(clip,pitch);
    }

    // @brief  : BGM読み込み
    //--------------------------------------------------------------------
    public static BGM LoadBGM(AudioClip clip, float pitch = 1.0f)
    {
        if(!Instance) return null;
        return Instance.LoadBackGroundMusic(clip,pitch);
    }

    // @brief  : BGM読み込み
    // @param  : クリップ名
    //         : ピッチ
    // @return : 再生用クラス
    //--------------------------------------------------------------------
    private BGM LoadBackGroundMusic(AudioClip clip, float pitch)
    {
		// 正式名
		string name = clip.name;//+ "(" + pitch.ToString();
        
        // 名前から検索
        foreach( var i in bgmList )
        {
            if(i.name == name) return i;
        }
        
        // なければ作成
        // AudioSourceを追加
        AudioSource newSource = gameObject.AddComponent<AudioSource>(); 
        
        // AudioSource設定
        newSource.clip        = Object.Instantiate(clip);
        newSource.loop        = true;
        newSource.playOnAwake = true;
        
        // AudioSourceにあるclipの名前を書き換える
        newSource.clip.name = name;
        
        // ピッチの追加
        newSource.pitch     = pitch;
        
        // リストに追加
        BGM newBGM = new BGM(newSource);
        bgmList.Add(newBGM);

        // 作成したものを返す
        //Debug.Log("["+ ToString()+"]"+" LoadSoundEffect " + newBGM.name );
        return newBGM;
    }

    // @brief  : SE読み込み
    // @param  : クリップ名
    //         : クリップデータ
    // @return : 再生用クラス
    //--------------------------------------------------------------------
    private SE LoadSoundEffect(AudioClip clip, float pitch)
    {
		// 正式名
		string name = clip.name;//+ "(" + pitch.ToString();
        
        // 名前から検索
        foreach( var i in seList )
        {
            if(i.name == name) return i;
        }
        
        // なければ作成
        // AudioSourceを追加
        AudioSource newSource = gameObject.AddComponent<AudioSource>(); 
        
        // AudioSource設定
        newSource.clip        = Object.Instantiate(clip);
        newSource.loop        = false;
        newSource.playOnAwake = false;
		
        // AudioSourceにあるclipの名前を書き換える
        newSource.clip.name = name;
        
        // ピッチの変更
        newSource.pitch = pitch;
        
        // リストに追加
        SE newSE = new SE(newSource);
        seList.Add(newSE);

        // 作成したものを返す
        //Debug.Log("["+ ToString()+"]"+" LoadSoundEffect " + newSE.name );
        return newSE;
    }

    // @brief  : フェードイン
    // @param  : BGM
    //--------------------------------------------------------------------
    private void FadeInBGM(BGM source)
    {
        float nextVol = source.volume + Time.deltaTime;
        if(nextVol >= 1.0f)
        {
            source.volume = 1.0f;
            source.Play();
        }
        else
        {
            source.volume = nextVol;
        }
    }

    // @brief  : フェードアウト
    // @param  : BGM
    //--------------------------------------------------------------------
    private void FadeOutBGM(BGM source)
    {
        float nextVol = source.volume - Time.deltaTime;
        if(nextVol <= 0.0f)
        {
            source.volume = 1.0f;
            source.Stop();
        }
        else
        {
            source.volume = nextVol;
        }
    }
}