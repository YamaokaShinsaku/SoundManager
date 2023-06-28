using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SoundTest : MonoBehaviour
{
    [SerializeField]
    private SoundManager soundManager;
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
            // SoundManagerで音を再生
            soundManager.PlaySound(clip1);
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            // SoundManagerで音を再生
            soundManager.PlaySound(clip2);
        }
    }
}
