using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 音量管理を行う
/// </summary>
public class AudioSetting : MonoBehaviour
{
    // 音量調整スライダー
    [SerializeField]
    Slider masterVolumeSlider;
    [SerializeField]
    Slider bgmVolumeSlider;
    [SerializeField]
    Slider seVolumeSlider;

    // AudioSource
    [SerializeField]
    AudioSource bgmAudioSource;
    [SerializeField]
    AudioSource seAudioSource;

    // BGM・SEを格納するリスト
    public List<AudioClip> bgmLists;
    public List<AudioClip> seLists;

    // 音量管理UIが開かれているかどうか
    public bool isOpenSettingPanel = false;

    public static AudioSetting instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        // 保存した音量を反映する
        bgmVolumeSlider.value = UpdateVolume.bgmSliderValue;
        seVolumeSlider.value = UpdateVolume.seSliderValue;
    }

    // Update is called once per frame
    void Update()
    {
        // スライダーの値を取得
        UpdateVolume.bgmSliderValue = bgmVolumeSlider.value;
        UpdateVolume.seSliderValue = seVolumeSlider.value;
        // オーディオの音量を設定
        bgmAudioSource.volume = UpdateVolume.bgmSliderValue * masterVolumeSlider.value;
        seAudioSource.volume = UpdateVolume.seSliderValue * masterVolumeSlider.value;

        // スライダーの値が変更されたときの処理を登録
        bgmVolumeSlider.onValueChanged.AddListener(ChangeBGMVolume);
        seVolumeSlider.onValueChanged.AddListener(ChangeSEVolume);
    }

    /// <summary>
    /// BGMの音量を変更
    /// </summary>
    void ChangeBGMVolume(float newVolume)
    {
        // スライダーの値に応じて音量を変更
        bgmAudioSource.volume = newVolume;
    }

    void ChangeSEVolume(float newVolume)
    {
        // スライダーの値に応じて音量を変更
        seAudioSource.volume = newVolume;
    }

    public float ReturnBGMVolume()
    {
        return bgmVolumeSlider.value * masterVolumeSlider.value;
    }

    public float ReturnSEVolume()
    {
        return seVolumeSlider.value * masterVolumeSlider.value;
    }
}
