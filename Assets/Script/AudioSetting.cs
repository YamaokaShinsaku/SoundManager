using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���ʊǗ����s��
/// </summary>
public class AudioSetting : MonoBehaviour
{
    // ���ʒ����X���C�_�[
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

    // BGM�ESE���i�[���郊�X�g
    public List<AudioClip> bgmLists;
    public List<AudioClip> seLists;

    // ���ʊǗ�UI���J����Ă��邩�ǂ���
    public bool isOpenSettingPanel = false;

    public static AudioSetting instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        // �ۑ��������ʂ𔽉f����
        bgmVolumeSlider.value = UpdateVolume.bgmSliderValue;
        seVolumeSlider.value = UpdateVolume.seSliderValue;
    }

    // Update is called once per frame
    void Update()
    {
        // �X���C�_�[�̒l���擾
        UpdateVolume.bgmSliderValue = bgmVolumeSlider.value;
        UpdateVolume.seSliderValue = seVolumeSlider.value;
        // �I�[�f�B�I�̉��ʂ�ݒ�
        bgmAudioSource.volume = UpdateVolume.bgmSliderValue * masterVolumeSlider.value;
        seAudioSource.volume = UpdateVolume.seSliderValue * masterVolumeSlider.value;

        // �X���C�_�[�̒l���ύX���ꂽ�Ƃ��̏�����o�^
        bgmVolumeSlider.onValueChanged.AddListener(ChangeBGMVolume);
        seVolumeSlider.onValueChanged.AddListener(ChangeSEVolume);
    }

    /// <summary>
    /// BGM�̉��ʂ�ύX
    /// </summary>
    void ChangeBGMVolume(float newVolume)
    {
        // �X���C�_�[�̒l�ɉ����ĉ��ʂ�ύX
        bgmAudioSource.volume = newVolume;
    }

    void ChangeSEVolume(float newVolume)
    {
        // �X���C�_�[�̒l�ɉ����ĉ��ʂ�ύX
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
