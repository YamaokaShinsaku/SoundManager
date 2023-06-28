using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SoundTest : MonoBehaviour
{
    [SerializeField]
    private SoundManager soundManager;
    // �����f�[�^�P
    [SerializeField]
    private AudioClip clip1;
    // �����f�[�^�Q
    [SerializeField]
    private AudioClip clip2;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            // SoundManager�ŉ����Đ�
            soundManager.PlaySound(clip1);
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            // SoundManager�ŉ����Đ�
            soundManager.PlaySound(clip2);
        }
    }
}
