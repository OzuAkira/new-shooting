using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class stage_1 : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image image;
    [SerializeField] weakEnemies weakEnemies;

    //別スクリプトからコルーチンを呼ぶ感じで行こうと思てる

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

        //フェードイン＆フェードアウト
        while (loop == false)
        {
            //Debug.Log("i= " + i);
            if (i < 1 && isMax == false) i += add_i;//Maxまで0.01づつ上げる

            else if (isMax == false)//Maxまで行ったら、１秒待ってフラグを立てる
            {
                yield return new WaitForSeconds(1);
                isMax = true;
            }

            if (isMax)i -= add_i;//Minまで0.0１づつ減らす

            c.a = i;
            image.color = c;
            yield return null;

            if (i <= 0 && isMax) loop = true;//iが0になったらWhileから脱出
        }
    }

    




}
