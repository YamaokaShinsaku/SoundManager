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
            // SoundManagerで音を再生
            soundManager.PlaySE("打ち上げ花火");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            // SoundManagerで音を再生
            soundManager.PlaySE("風鈴");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // SoundManagerで音を再生
            soundManager.PlaySE("ダイビング");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // SoundManagerで音を再生
            soundManager.PlaySE("氷グラス");
        }
        if (Input.GetKey(KeyCode.Alpha0))
        {
            // SoundManagerで音を再生
            soundManager.PlaySE("風鈴");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            // SoundManagerで音を再生
            soundManager.PlayBGM("BGM",3.0f);
        }
    }
}
