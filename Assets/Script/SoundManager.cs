using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// 音源データ
    /// </summary>
    [System.Serializable]
    public class SoundData
    {
        // サウンド名
        public string name;
        // 音源データ
        public AudioClip audioClip;
        // 前回再生した時間
        public float playedTime;
    }

    // 別名(name)をキーとした管理用Dictionary
    private Dictionary<string, SoundData> soundDictionary = new Dictionary<string, SoundData>();

    // AudioSourceを同時に鳴らしたい音の数だけ用意する
    private AudioSource[] audioSourceList = new AudioSource[20];

    // 一度再生してから、次再生するまでの間隔（秒）
    [SerializeField]
    private float playableDistance = 0.2f;

    [SerializeField]
    private SoundData[] soundDatas;

    private void Awake()
    {
        // audioSourceList配列の数だけAudioSourceを自分自身に生成して、配列に格納
        for(var i = 0; i < audioSourceList.Length; i++)
        {
            audioSourceList[i] = gameObject.AddComponent<AudioSource>();
        }

        // soundDirectionaryにセット
        foreach(var soundData in soundDatas)
        {
            soundDictionary.Add(soundData.name, soundData);
        }
    }

    /// <summary>
    /// 未使用のAudioSourceの取得
    /// </summary>
    /// <returns>
    /// 未使用のAudioSource
    /// すべて使用中の場合は null を返す
    /// </returns>
    private AudioSource GetUnusedAudioSource()
    {
        for(var i = 0; i < audioSourceList.Length; i++)
        {
            // 未使用のAudioSourceが存在するとき
            if (!audioSourceList[i].isPlaying)
            {
                return audioSourceList[i];
            }
        }

        // 未使用のAudioSourceが見つからないとき
        Debug.Log("未使用のAudioSourceが存在しません");
        return null;
    }

    /// <summary>
    /// 指定されたAudioClipを未使用のAudioSourceで再生
    /// </summary>
    /// <param name="clip">音源データ</param>
    public void PlaySound(AudioClip clip)
    {
        // 未使用のAudioSourceを取得
        var audioSource = GetUnusedAudioSource();

        // AudioSourceが存在しないとき
        if(!audioSource)
        {
            Debug.Log("未使用のAudioSourceが存在しません");
            return;
        }
        // 音源を取得
        audioSource.clip = clip;
        // 音を再生
        audioSource.Play();
    }

    /// <summary>
    /// 設定された別名(サウンド名)で登録されたAudioClipを再生
    /// </summary>
    /// <param name="name">設定した別名</param>
    public void PlaySound(string name)
    {
        // 管理用Directionaryから、別名(サウンド名）で検索
        if(soundDictionary.TryGetValue(name, out var soundData))
        {
            // まだ再生するには早い場合
            if(Time.realtimeSinceStartup - soundData.playedTime < playableDistance)
            {
                return;
            }
            // 次回の再生用に、今回の再生時間を保持する
            soundData.playedTime = Time.realtimeSinceStartup;
            // 音源が見つかったら、再生
            PlaySound(soundData.audioClip);
        }
        // 音源が見つからなかったら
        else
        {
            Debug.LogWarning($"その別名は登録されていません : {name}");
        }
    }
}
