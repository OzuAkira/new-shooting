using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSetting : MonoBehaviour
{
    void Awake()
    {
        // VSyncCount �� Dont Sync �ɕύX
        QualitySettings.vSyncCount = 0;
        // 60fps��ڕW�ɐݒ�
        Application.targetFrameRate = 60;   
    }
}
