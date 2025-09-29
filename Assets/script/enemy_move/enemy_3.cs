using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_3 : MonoBehaviour
{
    Vector3 myPos ;
    [SerializeField] float addPos = 0.01f , stopPos = 0;
    Rigidbody2D rb;

    public bool interval_flag = false;
    [SerializeField] GameObject straight_bulled;
    void Start()
    {
        myPos = gameObject.transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();

        StartCoroutine(move());
    }
    IEnumerator move()
    {
        int loop_n = 10, count = 0 ;
        while (myPos.y > stopPos)
        {
            myPos += new Vector3(0, addPos, 0);
            rb.MovePosition(myPos);
            yield return null;
        }
        if (interval_flag) yield return new WaitForSeconds(1);//interval Ç≈ä‘äuÇí≤êÆ
        while (true)
        {
            count++;
            
            for (int i=0;i<loop_n;i++) 
            {
                if(interval_flag) Instantiate(straight_bulled, gameObject.transform.position, Quaternion.Euler(0, 0, -90 + i * 18));
                else Instantiate(straight_bulled, gameObject.transform.position, Quaternion.Euler(0, 0, 90 - i * 18));
            }
            if (count > 5) 
            {
                yield return new WaitForSeconds(1.5f);
                count = 0;
            }
            else yield return new WaitForSeconds(0.1f);

        }
    }
}
