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
        //����炷
        yield return null;
        #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
        #else
                    Application.Quit();//�Q�[���v���C�I��
        #endif

    }
    
    
}
