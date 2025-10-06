using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class big_eim : MonoBehaviour
{
    public GameObject playerObj , child_EimObj;
    public bool minus = false;

    Rigidbody2D rb;
    Vector2 move_vector;
    [SerializeField] Vector3 goale_1 = new Vector3(3,-1,0), goale_2 = new Vector3(-3,-1,0);
    float moveSpeed = 0.01f;
    void Start()
    {
        playerObj = GameObject.Find("player");
        move_vector = transform.position - playerObj.transform.position;
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(move());
    }
    Vector3 startPos = new Vector3(0,3);
    IEnumerator move()
    {
        bool isIns = false , isIns_2 = false;
        List<childEim> childEims = new List<childEim>();

        if (minus)
        {
            while (gameObject.transform.position != startPos + goale_2)
            {
                move_vector = transform.position + goale_2 * moveSpeed;

                if (gameObject.transform.position.x < goale_2.x) transform.position = startPos + goale_2;
                else if (isIns== false && gameObject.transform.position.x < goale_2.x / 3)
                {
                    isIns = true;
                    childEims.Add( Instantiate(child_EimObj, gameObject.transform.position, Quaternion.identity).GetComponent<childEim>());
                }

                else if (isIns_2 == false && gameObject.transform.position.x < (goale_2.x / 3)*2)
                {
                    isIns_2 = true;
                    childEims.Add(Instantiate(child_EimObj, gameObject.transform.position, Quaternion.identity).GetComponent<childEim>());
                }

                rb.MovePosition(move_vector);
                yield return null;
            }
        }
        else
        {
            while (gameObject.transform.position != startPos + goale_1)
            {
                move_vector = transform.position + goale_1 * moveSpeed;

                if (gameObject.transform.position.x > goale_1.x) transform.position = startPos + goale_1;
                else if (isIns == false && gameObject.transform.position.x > goale_1.x / 3)
                {
                    isIns = true;
                    childEims.Add(Instantiate(child_EimObj, gameObject.transform.position, Quaternion.identity).GetComponent<childEim>());
                }

                else if (isIns_2 == false && gameObject.transform.position.x > (goale_1.x / 3)*2)
                {
                    isIns_2 = true;
                    childEims.Add(Instantiate(child_EimObj, gameObject.transform.position, Quaternion.identity).GetComponent<childEim>());
                }

                rb.MovePosition(move_vector);
                yield return null;
            }
        }
        Debug.Log("!!!");
        foreach (var child in childEims)
        {
            child.finish = true;
        }
    }
}
