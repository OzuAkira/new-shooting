using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSetting : MonoBehaviour
{
    void Awake()
    {
        // VSyncCount ‚ğ Dont Sync ‚É•ÏX
        QualitySettings.vSyncCount = 0;
        // 60fps‚ğ–Ú•W‚Éİ’è
        Application.targetFrameRate = 60;   
    }
}
