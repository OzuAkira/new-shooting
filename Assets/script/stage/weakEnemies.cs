using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weakEnemies : MonoBehaviour
{
    public GameObject enemy_1 , enemy_2 , enemy_3;
    public Vector2 enemy3_pos;

    int count = 10;

    int next_count = 8;
    float wait_s = 0.5f;

    public IEnumerator enemy_A()
    {
        //¶’[‚©‚çCount•C‚Ì“G‚ªoŒ»
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemy_1,gameObject.transform.position,Quaternion.identity);
            yield return new WaitForSeconds(wait_s);

            if (i == next_count) StartCoroutine(enemy_B());//  ”ñ“¯Šú‚ÅÀs

        }
    }
    IEnumerator enemy_B()
    {
        Vector3 pos = gameObject.transform.position;//‘‚­‚Ì‚ª‚ß‚ñ‚Ç‚­‚³‚¢‚Ì‚Å•Ï”‚É‚µ‚½

        //‰E’[‚©‚çCount•C‚Ì“G‚ªoŒ»
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemy_2 ,new Vector3(pos.x * -1 , pos.y,pos.z),Quaternion.identity);

            yield return new WaitForSeconds(wait_s);

            if(i == count-1)Instantiate(enemy_3 , enemy3_pos , Quaternion.identity);
        }
    }
}
