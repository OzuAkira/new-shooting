using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class stage_1 : MonoBehaviour
{
    [SerializeField]UnityEngine.UI.Image image;
    void Start()
    {
        StartCoroutine(gameStart());
    }
    IEnumerator gameStart()
    {
        UnityEngine.Color c = image.color;
        bool loop = false , isMax = false ;
        int i = 0;
        while (loop == false)
        {
            Debug.Log("i= " + i);
            if (i < 255 && isMax == false)
            {
                i++;//Max�܂�1�Âグ��
                yield return null;
            }
            else if (isMax == false)//Max�܂ōs������A�P�b�҂��ăt���O�𗧂Ă�
            {
                yield return new WaitForSeconds(1);
                isMax = true;
            }
            if (isMax)
            {
                i--;//Min�܂łP�Â��炷
                yield return null;
            }
            c.a = i;
            image.color = c;

            if (i <= 0 && isMax) loop = true;//i��0�ɂȂ�����While����E�o
        }
        
    }
}
