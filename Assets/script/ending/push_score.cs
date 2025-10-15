using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class push_score : MonoBehaviour
{
    public GameObject anykye_Obj;
    private GameObject resureection_Obj , playerObj;
    public GameObject[] textObj;
    public Vector2 goalPos , movePos;

    private void Start()
    {
        resureection_Obj = GameObject.Find("GameMaster");
        playerObj = GameObject.Find("player");
    }
    public IEnumerator first_move(bool isClear)
    {
        RectTransform rt;
        int i = 0;
        while (i < 120)
        {
            i++;
            if (Input.anyKey) break;
        }
        rt = textObj[0].GetComponent<RectTransform>();
        Text score = GameObject.Find("Canvas_2").transform.GetChild(4).GetComponent<Text>() , my_textObj = textObj[0].GetComponent<Text>();
        my_textObj.text = score.text;
        while (rt.anchoredPosition != goalPos)
        {
            rt.anchoredPosition += movePos;
            if (rt.anchoredPosition.y > goalPos.y) rt.anchoredPosition = goalPos;
            yield return null;
        }
        if (isClear)
        {
            rt = textObj[1].GetComponent<RectTransform>();
            goalPos = new Vector2(0,0);
            Resurrection res = resureection_Obj.GetComponent<Resurrection>();
            player_shot player_Shot = playerObj.GetComponent<player_shot>();
            int p= res._player, b=res._bom , pp = player_Shot.my_power;//playerとbomを取得

            yield return new WaitForSeconds(1.5f);

            while (rt.anchoredPosition != goalPos)
            {
                rt.anchoredPosition += movePos;
                if (rt.anchoredPosition.y > goalPos.y) rt.anchoredPosition = goalPos;
                yield return null;
            }

            yield return new WaitForSeconds(1.5f);

            my_textObj.text = ((int.Parse(my_textObj.text) + pp * b) * p).ToString();
        }

        bool isPush = false;
        i = 0;

        yield return new WaitForSeconds(1.5f);

        while (true)
        {
            
            if (Input.anyKey) isPush = true;
            if (isPush)
            {
                SceneManager.LoadScene("TitleScene");
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
