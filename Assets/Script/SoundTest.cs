using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SoundTest : MonoBehaviour
{
    [SerializeField]
    private SoundManager soundManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            // SoundManager�ŉ����Đ�
            soundManager.PlaySE("�ł��グ�ԉ�");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            // SoundManager�ŉ����Đ�
            soundManager.PlaySE("����");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // SoundManager�ŉ����Đ�
            soundManager.PlaySE("�_�C�r���O");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // SoundManager�ŉ����Đ�
            soundManager.PlaySE("�X�O���X");
        }
        if (Input.GetKey(KeyCode.Alpha0))
        {
            // SoundManager�ŉ����Đ�
            soundManager.PlaySE("����");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            // SoundManager�ŉ����Đ�
            soundManager.PlayBGM("BGM",3.0f);
        }
    }
}
