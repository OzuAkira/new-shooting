using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class stageBoss_1 : MonoBehaviour

//ボスは全ての処理をこのスクリプトで実行する
{
    [SerializeField] float start_y_Pos = 3 , moveSpeed;
    [SerializeField] GameObject HP_slider;

    [SerializeField] GameObject[] phase_1_bullet;

    Rigidbody2D rb;
    BoxCollider2D bc;

    bool isPhase_1 = false;

    
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        bc.enabled = false;//最初は無敵

        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(buttleStart());//登場＆無敵解除
    }
    IEnumerator buttleStart()
    {
        //下に降りてくるやつ
        while (gameObject.transform.position.y > start_y_Pos)
        {
            Vector2 pos = gameObject.transform.position - new Vector3(0,moveSpeed,0);
            rb.MovePosition(pos);

            yield return null;
        }

        yield return new WaitForSeconds(2);

        Instantiate(HP_slider);//HPバーを表示
        bc.enabled = true;//当たり判定をture

        StartCoroutine(phase_1());
    }

    int circleNum = 45 ;
    float addAngle = 4;

    float ms_1=0.05f , ms_2=0.1f;

    IEnumerator phase_1()
    {
        while (true)
        {
            for (int i = 0; i < circleNum; i++)
            {
                Straight_move straight_Move = Instantiate(phase_1_bullet[0], gameObject.transform.position, Quaternion.Euler(0, 0, i * 8))
                    .GetComponent<Straight_move>();
                straight_Move.moveSpeed = ms_1;
            }
            yield return new WaitForSeconds(0.25f);

            for (int i = 0; i < circleNum; i++)
            {
                Straight_move straight_Move = Instantiate(phase_1_bullet[0], gameObject.transform.position, Quaternion.Euler(0, 0, i * 8 +addAngle))
                    .GetComponent<Straight_move>();
                straight_Move.moveSpeed = ms_2;
            }
            yield return new WaitForSeconds(3);
        }
    }
}
