using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SoundTest : MonoBehaviour
{
    // �X�s�[�J�[�ECD�v���C���[
    [SerializeField]
    private AudioSource audioSource;
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
            // �Đ�������clip���w��
            audioSource.clip = clip1; 
            // �Đ�
            audioSource.Play();
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            //�Đ�������clip���w��
            audioSource.clip = clip2; 
            // �Đ�
            audioSource.Play(); 
        }
    }
}
