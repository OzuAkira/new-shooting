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
                i++;//Max‚Ü‚Å1‚Ã‚Âã‚°‚é
                yield return null;
            }
            else if (isMax == false)//Max‚Ü‚Ås‚Á‚½‚çA‚P•b‘Ò‚Á‚Äƒtƒ‰ƒO‚ð—§‚Ä‚é
            {
                yield return new WaitForSeconds(1);
                isMax = true;
            }
            if (isMax)
            {
                i--;//Min‚Ü‚Å‚P‚Ã‚ÂŒ¸‚ç‚·
                yield return null;
            }
            c.a = i;
            image.color = c;

            if (i <= 0 && isMax) loop = true;//i‚ª0‚É‚È‚Á‚½‚çWhile‚©‚ç’Eo
        }
        
    }
}
