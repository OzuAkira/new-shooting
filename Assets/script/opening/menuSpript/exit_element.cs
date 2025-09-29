using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit_element : Abs_menuElement
{
    public override void select()
    {
        StartCoroutine(end());
    }
    IEnumerator end()
    {
        //音を鳴らす
        yield return null;
        #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
        #else
                    Application.Quit();//ゲームプレイ終了
        #endif

    }
    
    
}
