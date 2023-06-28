using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // AudioSource�𓯎��ɖ炵�������̐������p�ӂ���
    private AudioSource[] audioSourceList = new AudioSource[20];

    private void Awake()
    {
        // audioSourceList�z��̐�����AudioSource���������g�ɐ������āA�z��Ɋi�[
        for(var i = 0; i < audioSourceList.Length; i++)
        {
            audioSourceList[i] = gameObject.AddComponent<AudioSource>();
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
}
