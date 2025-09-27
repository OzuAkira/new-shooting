using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_element : Abs_menuElement
{
    public override void select()
    {
        StartCoroutine("LoadScene");
    }

    IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("StageScene");

        // ���[�h���܂��Ȃ玟�̃t���[����
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
