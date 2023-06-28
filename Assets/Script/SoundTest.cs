using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SoundTest : MonoBehaviour
{
    // スピーカー・CDプレイヤー
    [SerializeField]
    private AudioSource audioSource;
    // 音源データ１
    [SerializeField]
    private AudioClip clip1;
    // 音源データ２
    [SerializeField]
    private AudioClip clip2;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            // 再生したいclipを指定
            audioSource.clip = clip1; 
            // 再生
            audioSource.Play();
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            //再生したいclipを指定
            audioSource.clip = clip2; 
            // 再生
            audioSource.Play(); 
        }
    }
}
