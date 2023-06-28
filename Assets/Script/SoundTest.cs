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
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            // SoundManagerで音を再生
            soundManager.PlaySound("打ち上げ花火");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            // SoundManagerで音を再生
            soundManager.PlaySound("風鈴");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // SoundManagerで音を再生
            soundManager.PlaySound("ダイビング");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // SoundManagerで音を再生
            soundManager.PlaySound("氷グラス");
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            // SoundManagerで音を再生
            soundManager.PlaySound("登録していない");
        }
    }
}
