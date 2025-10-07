using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spell_animetion : MonoBehaviour
{
    Vector2 goalPos = new Vector2(113, -113), startPos = new Vector2(-118, -50);//スタートとゴールの座標

    [SerializeField]float moveSpeed = 0.1f , alphaSpeed = 0.001f;

    RectTransform rectTransform;
    Image image;
    UnityEngine.Color color;

    public bool finish = false;
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();//UI座標を取得
        image = gameObject.GetComponent<Image>();
        color = image.color;//色を取得

        color.a = 0;
        image.color = color;//ここで色が反映される

        rectTransform.anchoredPosition = startPos;

        StartCoroutine(start_spell());
    }
    IEnumerator start_spell()
    {
        Vector2 Vector = goalPos - rectTransform.anchoredPosition;

        while (rectTransform.anchoredPosition != goalPos)
        {
            color.a +=alphaSpeed ;//1秒で不透明度100％
            image.color = color;

            rectTransform.anchoredPosition += Vector * moveSpeed;//移動
            if(rectTransform.anchoredPosition.x > goalPos.x)rectTransform.anchoredPosition = goalPos;//通り過ぎたら矯正
            yield return null;
        }

        yield return new WaitForSeconds(1);



        Vector3 addScale = new Vector3(0.01f,0.01f,0);
        
        while (image.color.a >= 0)//透明になるまで
        {
            color.a -= alphaSpeed*2;//0.5秒で不透明度0％
            image.color = color;

            rectTransform.localScale += addScale;
            yield return null;
            Debug.Log(image.color.a);
        }

        finish = true;
    }
}
