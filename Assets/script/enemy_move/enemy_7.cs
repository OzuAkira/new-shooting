using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class enemy_7 : MonoBehaviour
{
    [SerializeField] GameObject straght_bullet;
    int loop_int = 45 , i;
    [SerializeField] float stopPos = 3 , moveSpeed = -0.1f;

    float myXpos = 0;
    void Start()
    {
        StartCoroutine(firstMove());
    }
    IEnumerator firstMove()
    {
        while (gameObject.transform.position.y > stopPos)
        {
            gameObject.transform.position += new Vector3(0 , moveSpeed , 0);
            yield return null;
        }
        StartCoroutine(circl_bulled());
        while (true)
        {
            myXpos *= math.sin(i);
            i++;
            gameObject.transform.position += new Vector3(myXpos , 0);
            yield return null;
        }
    }
    IEnumerator circl_bulled()
    {
        while (true)
        {
            for (int i = 0; i < loop_int; i++)
            {
                Instantiate(straght_bullet,gameObject.transform.position , Quaternion.Euler(0,0,i*8));
            }
            yield return new WaitForSeconds(2);
        }
    }


}
