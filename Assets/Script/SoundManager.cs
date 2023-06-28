using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // AudioSourceを同時に鳴らしたい音の数だけ用意する
    private AudioSource[] audioSourceList = new AudioSource[20];

    private void Awake()
    {
        // audioSourceList配列の数だけAudioSourceを自分自身に生成して、配列に格納
        for(var i = 0; i < audioSourceList.Length; i++)
        {
            audioSourceList[i] = gameObject.AddComponent<AudioSource>();
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
}
