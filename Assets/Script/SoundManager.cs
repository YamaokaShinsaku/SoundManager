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
        // �O��Đ���������
        public float playedTime;
    }

    // �ʖ�(name)���L�[�Ƃ����Ǘ��pDictionary
    private Dictionary<string, SoundData> soundDictionary = new Dictionary<string, SoundData>();

    // AudioSource�𓯎��ɖ炵�������̐������p�ӂ���
    private AudioSource[] audioSourceList = new AudioSource[20];

    // ��x�Đ����Ă���A���Đ�����܂ł̊Ԋu�i�b�j
    [SerializeField]
    private float playableDistance = 0.2f;

    [SerializeField]
    private SoundData[] soundDatas;

    private void Awake()
    {
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
    /// ���g�p��AudioSource
    /// ���ׂĎg�p���̏ꍇ�� null ��Ԃ�
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
    public void PlaySound(AudioClip clip)
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
            // �܂��Đ�����ɂ͑����ꍇ
            if(Time.realtimeSinceStartup - soundData.playedTime < playableDistance)
            {
                return;
            }
            // ����̍Đ��p�ɁA����̍Đ����Ԃ�ێ�����
            soundData.playedTime = Time.realtimeSinceStartup;
            // ����������������A�Đ�
            PlaySound(soundData.audioClip);
        }
        // ������������Ȃ�������
        else
        {
            Debug.LogWarning($"���̕ʖ��͓o�^����Ă��܂��� : {name}");
        }
    }
}
