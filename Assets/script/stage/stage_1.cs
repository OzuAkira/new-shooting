using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class stage_1 : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image image;
    [SerializeField] weakEnemies weakEnemies;

    //�ʃX�N���v�g����R���[�`�����ĂԊ����ōs�����Ǝv�Ă�

    void Start()
    {
        
        StartCoroutine(game());
    }
    IEnumerator game()
    {
        yield return gameStart();
        yield return new WaitForSeconds(2); 
        yield return StartCoroutine(weakEnemies.enemy_A());
    }
    IEnumerator gameStart()
    {
        UnityEngine.Color c = image.color;
        bool loop = false, isMax = false;
        float i = 0 , add_i = 0.01f;

        //�t�F�[�h�C�����t�F�[�h�A�E�g
        while (loop == false)
        {
            //Debug.Log("i= " + i);
            if (i < 1 && isMax == false) i += add_i;//Max�܂�0.01�Âグ��

            else if (isMax == false)//Max�܂ōs������A�P�b�҂��ăt���O�𗧂Ă�
            {
                yield return new WaitForSeconds(1);
                isMax = true;
            }

            if (isMax)i -= add_i;//Min�܂�0.0�P�Â��炷

            c.a = i;
            image.color = c;
            yield return null;

            if (i <= 0 && isMax) loop = true;//i��0�ɂȂ�����While����E�o
        }
    }

    




}
