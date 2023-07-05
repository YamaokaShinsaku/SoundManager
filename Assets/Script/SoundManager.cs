using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// �����f�[�^
    /// </summary>
    [System.Serializable]
    public class SoundData
    {
        // �T�E���h��
        public string name;
        // �����f�[�^
        public AudioClip audioClip;
        // ����
        [Range(0.0f, 1.0f)]
        public float volume = 1.0f;
        // �O��Đ���������
        public float playedTime;
    }

    // �ő哯���Đ���
    [Range(5, 25)]
    public int maxSoundTrack = 10;

    // �ʖ�(name)���L�[�Ƃ����Ǘ��pDictionary
    private Dictionary<string, SoundData> soundDictionary = new Dictionary<string, SoundData>();

    // AudioSource�𓯎��ɖ炵�������̐������p�ӂ���
    private AudioSource[] audioSourceList = new AudioSource[20];

    [SerializeField]
    private SoundData[] soundDatas;

    private void Awake()
    {
        // maxSoundTrack����AudioSource���i�[
        audioSourceList = new AudioSource[maxSoundTrack];

        // audioSourceList�z��̐�����AudioSource���������g�ɐ������āA�z��Ɋi�[
        for(var i = 0; i < audioSourceList.Length; i++)
        {
            audioSourceList[i] = gameObject.AddComponent<AudioSource>();
        }

        // soundDirectionary�ɃZ�b�g
        foreach(var soundData in soundDatas)
        {
            soundDictionary.Add(soundData.name, soundData);
        }
    }

    /// <summary>
    /// ���g�p��AudioSource�̎擾
    /// </summary>
    /// <returns>
    /// ���g�p��AudioSource(���ׂĎg�p���̏ꍇ�� null)
    /// </returns>
    private AudioSource GetUnusedAudioSource()
    {
        for(var i = 0; i < audioSourceList.Length; i++)
        {
            // ���g�p��AudioSource�����݂���Ƃ�
            if (!audioSourceList[i].isPlaying)
            {
                return audioSourceList[i];
            }
        }

        // ���g�p��AudioSource��������Ȃ��Ƃ�
        Debug.Log("���g�p��AudioSource�����݂��܂���");
        return null;
    }

    /// <summary>
    /// �w�肳�ꂽAudioClip�𖢎g�p��AudioSource�ōĐ�
    /// </summary>
    /// <param name="clip">�����f�[�^</param>
    /// <param name="volume">����</param>
    /// SoundManager�����Ŏg�p
    public void PlaySound(AudioClip clip, float volume)
    {
        // ���g�p��AudioSource���擾
        var audioSource = GetUnusedAudioSource();

        // AudioSource�����݂��Ȃ��Ƃ�
        if(!audioSource)
        {
            Debug.Log("���g�p��AudioSource�����݂��܂���");
            return;
        }
        // �������擾
        audioSource.clip = clip;
        // ���ʂ��擾
        audioSource.volume = volume;
        // �����Đ�
        audioSource.Play();
    }

    /// <summary>
    /// �ݒ肳�ꂽ�ʖ�(�T�E���h��)�œo�^���ꂽAudioClip���Đ�
    /// </summary>
    /// <param name="name">�ݒ肵���ʖ�</param>
    public void PlaySound(string name)
    {
        // �Ǘ��pDirectionary����A�ʖ�(�T�E���h���j�Ō���
        if(soundDictionary.TryGetValue(name, out var soundData))
        {
            // �������Đ�����Ă���ꍇ
            if(Time.realtimeSinceStartup - soundData.playedTime < soundData.audioClip.length)
            {
                return;
            }
            // ����̍Đ��p�ɁA����̍Đ����Ԃ�ێ�����
            soundData.playedTime = Time.realtimeSinceStartup;
            // ����������������A�Đ�
            PlaySound(soundData.audioClip, soundData.volume);
        }
        // ������������Ȃ�������
        else
        {
            Debug.LogWarning($"���̕ʖ��͓o�^����Ă��܂��� : {name}");
        }
    }

    /// <summary>
    /// �ݒ肳�ꂽ�ʖ�(�T�E���h��)�A�Ԋu�œo�^���ꂽAudioClip���Đ�
    /// </summary>
    /// <param name="name"></param>
    /// <param name="intervalTime"></param>
    public void PlaySound(string name, float intervalTime)
    {
        // �Ǘ��pDirectionary����A�ʖ�(�T�E���h���j�Ō���
        if (soundDictionary.TryGetValue(name, out var soundData))
        {
            // �Đ��Ԋu�𒴂��Ă��Ȃ��Ƃ�
            if (Time.realtimeSinceStartup - soundData.playedTime < intervalTime)
            {
                return;
            }
            // ����̍Đ��p�ɁA����̍Đ����Ԃ�ێ�����
            soundData.playedTime = Time.realtimeSinceStartup;
            // ����������������A�Đ�
            PlaySound(soundData.audioClip, soundData.volume);
        }
        // ������������Ȃ�������
        else
        {
            Debug.LogWarning($"���̕ʖ��͓o�^����Ă��܂��� : {name}");
        }
    }
}
