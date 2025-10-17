using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class first_action : MonoBehaviour
{
    public Vector2 golePos = new Vector2(-130, 160) , menuPos = new Vector2(250,-80);
    public float titleMoveSpeed = 0.002f, menuMoveSpeed = 0.6f;
    public GameObject menuFolder , anykye_Obj , corsorObj;
    bool isPush , isCoroutine;
    RectTransform myRT,menuRT;
    int i = 0;
    private void Start()
    {
        myRT = gameObject.GetComponent<RectTransform>();
        menuRT = menuFolder.GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (Input.anyKey)isPush = true;
        if (isPush)
        {
            anykye_Obj.SetActive(false);
            
            if (isCoroutine == false) StartCoroutine(opening());
        }
        else
        {
            i++;
            if (i >= 90) anykye_Obj.SetActive(false);//1.5秒経ったら非表示
            if (i >= 120)//0.5秒後に表示し、iをリセット
            {
                anykye_Obj.SetActive(true);
                i = 0;
            }
        }

    }
    
    IEnumerator opening()
    {
        bool loop = false;
        isCoroutine = true;

        while (loop == false)
        {
            

            myRT.anchoredPosition += golePos * titleMoveSpeed;//titleオブジェクトは原点から始まるから、golePosがそのままベクトルになる

            menuRT.anchoredPosition -= new Vector2(menuMoveSpeed , 0);//X軸のみ移動。割り切れるので、下のIF文で矯正する必要が無い

            if (myRT.anchoredPosition.y > golePos.y)
            {
                myRT.anchoredPosition = golePos;
                loop = true;
                corsorObj.SetActive(true);
            }
            yield return null;
        }
    }
}
