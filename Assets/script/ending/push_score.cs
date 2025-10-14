using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push_score : MonoBehaviour
{
    public GameObject textObj , anykye_Obj;
    public Vector2 goalPos , movePos;
    public bool isClear = false;
    
    public IEnumerator first_move()
    {
    yield return new WaitForSeconds(3);
        RectTransform rt=textObj.GetComponent<RectTransform>();
        while(rt.anchoredPosition != goalPos)
        {
            rt.anchoredPosition += movePos;
            if(rt.anchoredPosition.y > goalPos.y) rt.anchoredPosition = goalPos;
            yield return null;
        }
        bool isPush = false;
        int i = 0;
        while (true)
        {
            
            if (Input.anyKey) isPush = true;
            if (isPush)
            {
                
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
            yield return null;
            
    }

}
}
